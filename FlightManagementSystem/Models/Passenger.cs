using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Passenger
    {
        public int passengerId { get; set; }
        public string passengerName { get; set; }
        public string passengerEmail { get; set; }
        public string passengerPhone { get; set; }
        public string passportNumber { get; set; }
        public string nationality { get; set; }

        public Passenger(int passengerId, string passengerName, string passengerEmail,
                         string passengerPhone, string passportNumber, string nationality)
        {
            passengerId = passengerId;
            passengerName = passengerName;
            passengerEmail = passengerEmail;
            passengerPhone = passengerPhone;
            passportNumber = passportNumber;
            nationality = nationality;
        }

        public void Display()
        {
            Console.WriteLine($"  ID: {passengerId} | Name: {passengerName} | Email: {passengerEmail} | Phone: {passengerPhone} | Passport: {passportNumber} | Nationality: {nationality}");
        }
    }
}
