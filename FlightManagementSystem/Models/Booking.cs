using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Booking
        {
        public int BookingId { get; set; }
        public int PassengerId { get; set; }
        public int FlightId { get; set; }
        public string SeatNumber { get; set; }
        public string BookingDate { get; set; }  
        public decimal TotalPrice { get; set; }  
        public string Status { get; set; }   

        public Booking(int bookingId, int passengerId, int flightId,
                       string seatNumber, decimal totalPrice)
        {
            BookingId = bookingId;
            PassengerId = passengerId;
            FlightId = flightId;
            SeatNumber = seatNumber;
            BookingDate = DateTime.Now.ToString("yyyy-MM-dd");  
            TotalPrice = totalPrice;
            Status = "Confirmed";  
        }

        public void Display()
        {
            Console.WriteLine($"  BookingID: {BookingId} | PassengerID: {PassengerId} | FlightID: {FlightId} | Seat: {SeatNumber} | Date: {BookingDate} | Price: OMR {TotalPrice:F2} | Status: {Status}");
        }
    }
}
