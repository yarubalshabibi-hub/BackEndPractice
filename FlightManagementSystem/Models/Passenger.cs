namespace FMS.Models
{
    class Passenger
    {
        public int PassengerId { get; set; }
        public string PassengerName { get; set; }
        public string PassengerEmail { get; set; }
        public string PassengerPhone { get; set; }
        public string PassportNumber { get; set; }
        public string Nationality { get; set; }

        public Passenger(int passengerId, string passengerName, string passengerEmail,
                         string passengerPhone, string passportNumber, string nationality)
        {
            PassengerId = passengerId;
            PassengerName = passengerName;
            PassengerEmail = passengerEmail;
            PassengerPhone = passengerPhone;
            PassportNumber = passportNumber;
            Nationality = nationality;
        }

        public void Display()
        {
            Console.WriteLine($"  ID: {PassengerId} | Name: {PassengerName} | Email: {PassengerEmail} | Phone: {PassengerPhone} | Passport: {PassportNumber} | Nationality: {Nationality}");
        }
    }
}
