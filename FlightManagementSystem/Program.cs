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
                            ; break;

                    case "2":
                        AddAircraft();
                        break;

                    case "3":
                        RegisterPilot();
                         break;

                    case "4":
                        ViewAllFlights();
                        break;

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
                }

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
                }

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
                }

                static void ViewAllFlights()
                {

                }

                static void ScheduleFlight()
                {

                }

                static void BookFlight()
                {

                }

                static void CancelBooking()
                {

                }

                static void DepartFlight()
                {

                }

                static void CancelFlight()
                {

                }

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
