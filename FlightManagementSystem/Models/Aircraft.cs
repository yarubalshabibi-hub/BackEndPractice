using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Aircraft
    {
        public int AircraftId { get; set; }
        public string Model { get; set; }
        public int TotalSeats { get; set; }
        public bool IsOperational { get; set; }

        public Aircraft(int aircraftId, string model, int totalSeats)
        {
            AircraftId = aircraftId;
            Model = model;
            TotalSeats = totalSeats;
            IsOperational = true;
        }

        public void Display()
        {
            string status = IsOperational ? "Operational" : "Grounded";
            Console.WriteLine($"  ID: {AircraftId} | Model: {Model} | Seats: {TotalSeats} | Status: {status}");
        }
    }
}

