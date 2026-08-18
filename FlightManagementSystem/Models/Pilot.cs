using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Pilot
    {
        public int pilotId { get; set; }
        public string pilotName { get; set; }
        public string pilotPhone { get; set; }
        public string licenseNumber { get; set; }
        public int flightHours { get; set; }
        public bool isAvailable { get; set; }

        public Pilot(int pilotId, string pilotName, string pilotPhone, string licenseNumber)
        {
            pilotId = pilotId;
            pilotName = pilotName;
            pilotPhone = pilotPhone;
            licenseNumber = licenseNumber;
            flightHours = 0;     
            isAvailable = true; 
        }

        public void Display()
        {
            string status = isAvailable ? "Available" : "Assigned";
            Console.WriteLine($"  ID: {pilotId} | Name: {pilotName} | License: {licenseNumber} | Hours: {flightHours} | Status: {status}");
        }
    }
}
