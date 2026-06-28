using FlightManagementSystem.Models;

namespace FlightManagementSystem
{
    public class Program
    {
        // ── Static context — all 5 lists live here ────────────
        // System Stoarge (The actual storage in the memory for all the lists)
        public static FlightContext context = new FlightContext
        {
            Passengers = new List<Passenger>(),

            Pilots = new List<Pilot>(),

            Aircrafts = new List<Aircraft>(),

            Flights = new List<Flight>(),

            Bookings = new List<Booking>()
        };

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("================================================");
                Console.WriteLine("       FLIGHT MANAGEMENT SYSTEM (FMS)");
                Console.WriteLine("================================================");
                Console.WriteLine(" 1.Register a Passenger");
                Console.WriteLine(" 2.Add an Aircraft");
                Console.WriteLine(" 3.Register a Pilot");
                Console.WriteLine(" 4.View All Flights");
                Console.WriteLine(" 5.Schedule a Flight");
                Console.WriteLine(" 6.Book a Flight");
                Console.WriteLine(" 7.Cancel a Booking");
                Console.WriteLine(" 8.Depart a Flight");
                Console.WriteLine(" 9.Cancel a Flight");
                Console.WriteLine("10.Passenger Booking History");
                Console.WriteLine("11.Flight Revenue & Load Factor Report");
                Console.WriteLine(" 0.Exit");
                Console.WriteLine("================================================");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": RegisterPassenger()
                            ; break; //Done

                    case "2":
                        AddAircraft();
                        break; //Done

                    case "3":
                        RegisterPilot();
                         break; //Done

                    case "4":
                        ViewAllFlights();
                        break; //Done

                    case "5": ScheduleFlight();
                        break;

                    case "6":
                        BookFlight();
                        break;

                    case "7":
                        CancelBooking();
                         break;

                    case "8":
                        DepartFlight();
                         break;

                    case "9":
                        CancelFlight();
                         break;

                    case "10":
                        PassengerHistory();
                         break;

                    case "11":
                        RevenueReport();
                         break;

                    case "0":
                        running = false; Console.WriteLine("Goodbye!");
                        break;

                    default: Console.WriteLine("Invalid choice Try again.");
                        break;
                }
                static void RegisterPassenger()
                {
                    Console.WriteLine("Register a Passenger");

                    Console.Write("Enter full name: ");
                    string name = Console.ReadLine().Trim();

                    Console.Write("Enter email: ");
                    string email = Console.ReadLine().Trim();

                    Console.Write("Enter phone: ");
                    string phone = Console.ReadLine().Trim();

                    Console.Write("Enter passport number: ");
                    string passport = Console.ReadLine().Trim();

                    // Passport must be unique
                    if (context.Passengers.Any(p => p.PassportNumber == passport))
                    {
                        Console.WriteLine("Error: A passenger with this passport number already exists.");
                        return;
                    }

                    Console.Write("Enter nationality: ");
                    string nationality = Console.ReadLine().Trim();

                    // Auto-generate ID
                    int PassengerId = context.Passengers.Count + 1;

                    context.Passengers.Add(new Passenger(PassengerId, name, email, phone, passport, nationality));

                    Console.WriteLine($"Passenger registered successfully! The passenger ID: {PassengerId}");
                } //Done

                static void AddAircraft()
                {
                    Console.WriteLine("Add an Aircraft: ");

                    Console.Write("Enter aircraft model (e.g. Boeing 737): ");
                    string model = Console.ReadLine().Trim();

                    int seats;
                    while (true)
                    {
                        Console.Write("Enter total seats: ");
                        if (int.TryParse(Console.ReadLine(), out seats) && seats > 0) break;
                        Console.WriteLine("Error: Enter a valid positive number.");
                    }

                    int newId = context.Aircrafts.Count + 1;
                    context.Aircrafts.Add(new Aircraft(newId, model, seats));

                    Console.WriteLine($" Aircraft added! Assigned ID: {newId} | Model: {model} | Seats: {seats} | Status: Operational");
                } //Done

                static void RegisterPilot()
                {
                    Console.WriteLine("Register a Pilot: ");

                    Console.Write("Enter pilot full name: ");
                    string name = Console.ReadLine().Trim();

                    Console.Write("Enter phone: ");
                    string phone = Console.ReadLine().Trim();

                    Console.Write("Enter license number: ");
                    string license = Console.ReadLine().Trim();

                    // License must be unique
                    if (context.Pilots.Any(p => p.LicenseNumber == license))
                    {
                        Console.WriteLine("Error: A pilot with this license number already exists.");
                        return;
                    }

                    int newId = context.Pilots.Count + 1;
                    context.Pilots.Add(new Pilot(newId, name, phone, license));

                    Console.WriteLine($" Pilot registered! Assigned ID: {newId}");
                } //Done

                static void ViewAllFlights()
                {
                    Console.WriteLine("All Flights: ");

                    if (context.Flights.Count == 0)
                    {
                        Console.WriteLine("No flights scheduled yet.");
                        return;
                    }

                    context.Flights.ForEach(f => f.Display());
                } //Done

                static void ScheduleFlight()
                {
                    Console.WriteLine(" Schedule a Flight: ");

                    // Show operational aircraft
                    var opAircrafts = context.Aircrafts.Where(a => a.IsOperational).ToList();
                    if (opAircrafts.Count == 0)
                    {
                        Console.WriteLine("No operational aircraft available.");
                        return;
                    }
                    Console.WriteLine("Available Aircraft:");
                    opAircrafts.ForEach(a => a.Display());

                    int aircraftId;
                    while (true)
                    {
                        Console.Write("Enter Aircraft ID: ");
                        if (int.TryParse(Console.ReadLine(), out aircraftId)) break;
                    }
                    Aircraft aircraft = context.Aircrafts.FirstOrDefault(a => a.AircraftId == aircraftId && a.IsOperational);
                    if (aircraft == null)
                    {
                        Console.WriteLine("Error: Aircraft not found or not operational.");
                        return;
                    }

                    // Show available pilots
                    var availPilots = context.Pilots.Where(p => p.IsAvailable).ToList();
                    if (availPilots.Count == 0)
                    {
                        Console.WriteLine("No available pilots.");
                        return;
                    }
                    Console.WriteLine("Available Pilots:");
                    availPilots.ForEach(p => p.Display());

                    int pilotId;
                    while (true)
                    {
                        Console.Write("Enter Pilot ID: ");
                        if (int.TryParse(Console.ReadLine(), out pilotId)) break;
                    }
                    Pilot pilot = context.Pilots.FirstOrDefault(p => p.PilotId == pilotId && p.IsAvailable);
                    if (pilot == null)
                    {
                        Console.WriteLine("Error: Pilot not found or not available.");
                        return;
                    }

                    Console.Write("Enter origin city/airport: ");
                    string origin = Console.ReadLine().Trim();

                    Console.Write("Enter destination city/airport: ");
                    string destination = Console.ReadLine().Trim();

                    Console.Write("Enter departure date (e.g. 2025-09-01): ");
                    string date = Console.ReadLine().Trim();

                    Console.Write("Enter departure time (e.g. 08:00): ");
                    string time = Console.ReadLine().Trim();

                    decimal price;
                    while (true)
                    {
                        Console.Write("Enter ticket price (OMR): ");
                        if (decimal.TryParse(Console.ReadLine(), out price) && price > 0) break;
                        Console.WriteLine("Error: Enter a valid positive price.");
                    }

                    int flightDuration;
                    while (true)
                    {
                        Console.Write("Enter flight duration (hours): ");
                        if (int.TryParse(Console.ReadLine(), out flightDuration) && flightDuration > 0) break;
                        Console.WriteLine("Error: Enter a valid positive number of hours.");
                    }

                    // Auto-generate flight ID and code
                    int newId = context.Flights.Count + 1;
                    string flightCode = $"OA-{200 + newId}";   // e.g. OA-201, OA-202 ...

                    context.Flights.Add(new Flight(newId, flightCode, aircraftId, pilotId,
                                              origin, destination, date, time, price, aircraft.TotalSeats, flightDuration));

                    // Mark pilot as not available
                    pilot.IsAvailable = false;

                    Console.WriteLine($"Flight scheduled! Code: {flightCode} | {origin} → {destination} | {date} {time} | Duration: {flightDuration}h | Seats: {aircraft.TotalSeats}");
                }//Done

                static void BookFlight()
                {
                    Console.WriteLine("Book a Flight: ");

                    // Show passengers
                    if (context.Passengers.Count == 0)
                    {
                        Console.WriteLine("No passengers registered yet.");
                        return;
                    }
                    Console.WriteLine("Registered Passengers:");
                    context.Passengers.ForEach(p => Console.WriteLine($"  ID: {p.PassengerId} | {p.PassengerName}"));

                    int passengerId;
                    while (true)
                    {
                        Console.Write("Enter Passenger ID: ");
                        if (int.TryParse(Console.ReadLine(), out passengerId)) break;
                    }
                    Passenger passenger = context.Passengers.FirstOrDefault(p => p.PassengerId == passengerId);
                    if (passenger == null)
                    {
                        Console.WriteLine("Error: Passenger not found.");
                        return;
                    }

                    Console.Write("Enter destination: ");
                    string destination = Console.ReadLine().Trim();

                    // Show scheduled flights to that destination with seats available
                    var matchFlights = context.Flights
                        .Where(f => f.Destination.ToLower() == destination.ToLower()
                                 && f.Status == "Scheduled"
                                 && f.AvailableSeats > 0)
                        .ToList();

                    if (matchFlights.Count == 0)
                    {
                        Console.WriteLine("No available flights to that destination.");
                        return;
                    }

                    Console.WriteLine("Available Flights:");
                    matchFlights.ForEach(f => f.Display());

                    int flightId;
                    while (true)
                    {
                        Console.Write("Enter Flight ID: ");
                        if (int.TryParse(Console.ReadLine(), out flightId)) break;
                    }
                    Flight flight = matchFlights.FirstOrDefault(f => f.FlightId == flightId);
                    if (flight == null)
                    {
                        Console.WriteLine("Error: Flight not found in the list.");
                        return;
                    }

                    // Auto-generate seat number based on bookings on this flight
                    int seatNum = context.Bookings.Count(b => b.FlightId == flightId) + 1;
                    string seatLabel = $"{seatNum}A";

                    int newId = context.Bookings.Count + 1;
                    context.Bookings.Add(new Booking(newId, passengerId, flightId, seatLabel, flight.TicketPrice));

                    // Decrease available seats
                    flight.AvailableSeats--;

                    Console.WriteLine($"Booking confirmed! BookingID: {newId} | Seat: {seatLabel} | Price: OMR {flight.TicketPrice:F2}");
                }

                static void CancelBooking()
                {
                    Console.WriteLine("Cancel a Booking: ");

                    int bookingId;
                    while (true)
                    {
                        Console.Write("Enter Booking ID to cancel: ");
                        if (int.TryParse(Console.ReadLine(), out bookingId)) break;
                    }

                    Booking booking = context.Bookings.FirstOrDefault(b => b.BookingId == bookingId);
                    if (booking == null)
                    {
                        Console.WriteLine("Error: Booking not found.");
                        return;
                    }

                    if (booking.Status == "Cancelled")
                    {
                        Console.WriteLine("Error: Booking is already cancelled.");
                        return;
                    }

                    // Find the linked flight
                    Flight flight = context.Flights.FirstOrDefault(f => f.FlightId == booking.FlightId);
                    if (flight != null && flight.Status == "Departed")
                    {
                        Console.WriteLine("Error: Cannot cancel a booking on a departed flight.");
                        return;
                    }

                    // Cancel booking and restore seat
                    booking.Status = "Cancelled";
                    if (flight != null) flight.AvailableSeats++;

                    Console.WriteLine($"Booking {bookingId} cancelled! Seat returned to flight.");
                }

                static void DepartFlight()
                {

                }

                static void CancelFlight()
                {
                    Console.WriteLine("Cancel a Flight: ");

                    int flightId;
                    while (true)
                    {
                        Console.Write("Enter Flight ID to cancel: ");
                        if (int.TryParse(Console.ReadLine(), out flightId)) break;
                    }

                    Flight flight = context.Flights.FirstOrDefault(f => f.FlightId == flightId);
                    if (flight == null)
                    {
                        Console.WriteLine("Error: Flight not found.");
                        return;
                    }

                    if (flight.Status == "Departed")
                    {
                        Console.WriteLine("Error: Cannot cancel a flight that has already departed.");
                        return;
                    }

                    if (flight.Status == "Cancelled")
                    {
                        Console.WriteLine("Error: Flight is already cancelled.");
                        return;
                }

                    // Cancel all confirmed bookings on this flight
                    var affectedBookings = context.Bookings
                        .Where(b => b.FlightId == flightId && b.Status == "Confirmed")
                        .ToList();

                    affectedBookings.ForEach(b => b.Status = "Cancelled");

                    // Free the pilot
                    Pilot pilot = context.Pilots.FirstOrDefault(p => p.PilotId == flight.PilotId);
                    if (pilot != null) pilot.IsAvailable = true;

                    // Cancel the flight
                    flight.Status = "Cancelled";

                    Console.WriteLine($"Flight {flight.FlightCode} cancelled.");
                    Console.WriteLine($"  Bookings affected and cancelled: {affectedBookings.Count}");
                    if (pilot != null)
                        Console.WriteLine($"Pilot {pilot.PilotName} is now available.");
                }  //Done

                static void PassengerHistory()
                {

                }

                static void RevenueReport()
                {

                }

               
            }
        }
    }
}
