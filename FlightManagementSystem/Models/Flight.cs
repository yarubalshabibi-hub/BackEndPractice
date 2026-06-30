using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Flight
    {
        public int flightId { get; set; }
        public string flightCode { get; set; }   
        public int aircraftId { get; set; }
        public int pilotId { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public string departureDate { get; set; }
        public string departureTime { get; set; }
        public decimal ticketPrice { get; set; }
        public int availableSeats { get; set; }
        public int flightDuration { get; set; }  
        public string status { get; set; }   

        public Flight(int flightId, string flightCode, int aircraftId, int pilotId,
                      string origin, string destination, string departureDate,
                      string departureTime, decimal ticketPrice, int availableSeats, int flightDuration)
        {
            flightId = flightId;
            flightCode = flightCode;
            aircraftId = aircraftId;
            pilotId = pilotId;
            origin = origin;
            destination = destination;
            departureDate = departureDate;
            departureTime = departureTime;
            ticketPrice = ticketPrice;
            availableSeats = availableSeats;
            flightDuration = flightDuration;
            status = "Scheduled";   
        }

        public void Display()
        {
            Console.WriteLine($"  [{flightCode}] {origin} → {destination} | Date: {departureDate} {departureTime} | Duration: {flightDuration}h | Seats Left: {availableSeats} | Price: OMR {ticketPrice:F2} | Status: {status}");
        }
    }
}
