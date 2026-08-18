using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Aircraft
    {
        public int aircraftId { get; set; }
        public string model { get; set; }
        public int totalSeats { get; set; }
        public bool isOperational { get; set; }

        public Aircraft(int aircraftId, string model, int totalSeats)
        {
            aircraftId = aircraftId;
            model = model;
            totalSeats = totalSeats;
            isOperational = true;
        }

        public void Display()
        {
            string status = isOperational ? "Operational" : "Grounded";
            Console.WriteLine($"  ID: {aircraftId} | Model: {model} | Seats: {totalSeats} | Status: {status}");
        }
    }
}

