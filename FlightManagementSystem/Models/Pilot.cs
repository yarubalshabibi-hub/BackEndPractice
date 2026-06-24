using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Pilot
    {
        public int PilotId { get; set; }
        public string PilotName { get; set; }
        public string PilotPhone { get; set; }
        public string LicenseNumber { get; set; }
        public int FlightHours { get; set; }
        public bool IsAvailable { get; set; }

        public Pilot(int pilotId, string pilotName, string pilotPhone, string licenseNumber)
        {
            PilotId = pilotId;
            PilotName = pilotName;
            PilotPhone = pilotPhone;
            LicenseNumber = licenseNumber;
            FlightHours = 0;     
            IsAvailable = true; 
        }

        public void Display()
        {
            string status = IsAvailable ? "Available" : "Assigned";
            Console.WriteLine($"  ID: {PilotId} | Name: {PilotName} | License: {LicenseNumber} | Hours: {FlightHours} | Status: {status}");
        }
    }
}
