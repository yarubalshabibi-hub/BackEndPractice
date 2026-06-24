using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string FlightCode { get; set; }   
        public int AircraftId { get; set; }
        public int PilotId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string DepartureDate { get; set; }
        public string DepartureTime { get; set; }
        public decimal TicketPrice { get; set; }
        public int AvailableSeats { get; set; }
        public int FlightDuration { get; set; }  
        public string Status { get; set; }   

        public Flight(int flightId, string flightCode, int aircraftId, int pilotId,
                      string origin, string destination, string departureDate,
                      string departureTime, decimal ticketPrice, int availableSeats, int flightDuration)
        {
            FlightId = flightId;
            FlightCode = flightCode;
            AircraftId = aircraftId;
            PilotId = pilotId;
            Origin = origin;
            Destination = destination;
            DepartureDate = departureDate;
            DepartureTime = departureTime;
            TicketPrice = ticketPrice;
            AvailableSeats = availableSeats;
            FlightDuration = flightDuration;
            Status = "Scheduled";   
        }

        public void Display()
        {
            Console.WriteLine($"  [{FlightCode}] {Origin} → {Destination} | Date: {DepartureDate} {DepartureTime} | Duration: {FlightDuration}h | Seats Left: {AvailableSeats} | Price: OMR {TicketPrice:F2} | Status: {Status}");
        }
    }
}
