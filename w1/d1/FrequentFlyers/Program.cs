using System;

namespace FrequentFlyers
{
    class Program
    {
        static void Main(string[] args)
        {
            // dataType varName = value
            int myNumber = 5;

            // Passenger IS a data type now.
            Passenger somePassenger = new Passenger("Neil", "Mos");
            Console.WriteLine(somePassenger.FullName());

            Flight vacationFlight = new Flight("J4L4", "B24", "C16", "SNA", "DEN", new DateTime(2021, 5, 10, 6, 10, 20), new DateTime(2021, 5, 10, 8, 10, 20));

            vacationFlight.BookedPassengers.Add(somePassenger);
            Console.WriteLine(vacationFlight.BookedPassengers[0].FullName());
        }
    }


}
