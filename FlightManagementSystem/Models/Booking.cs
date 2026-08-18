using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Booking
        {
        public int bookingId { get; set; }
        public int passengerId { get; set; }
        public int flightId { get; set; }
        public string seatNumber { get; set; }
        public string bookingDate { get; set; }  
        public decimal totalPrice { get; set; }  
        public string status { get; set; }   

        public Booking(int bookingId, int passengerId, int flightId,
                       string seatNumber, decimal totalPrice)
        {
            bookingId = bookingId;
            passengerId = passengerId;
            flightId = flightId;
            seatNumber = seatNumber;
            bookingDate = DateTime.Now.ToString("yyyy-MM-dd");  
            totalPrice = totalPrice;
            status = "Confirmed";  
        }

        public void Display()
        {
            Console.WriteLine($"  BookingID: {bookingId} | PassengerID: {passengerId} | FlightID: {flightId} | Seat: {seatNumber} | Date: {bookingDate} | Price: OMR {totalPrice:F2} | Status: {status}");
        }
    }
}
