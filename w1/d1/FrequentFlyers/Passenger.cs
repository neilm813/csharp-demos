using System;

namespace FrequentFlyers
{
    // A class has "Members" which are properties / fields and methods. These things have membership to the class.
    public class Passenger
    {
        // Auto-implemented Property
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        // Not using this, but this is a way to relate the passenger to a single flight.
        public Flight CurrentFlight { get; set; }

        // Constructor is a method with same name as class name. It auto returns the new instance.
        public Passenger(string firstName, string lastName)
        {
            // equivalent to this.FirstName = firstName
            // the class property is being set with the value from the parameter.
            FirstName = firstName;
            LastName = lastName;
        }

        // This is a 2nd constructor, but it has a different signature because it has different params
        public Passenger(string firstName, string lastName, int age)
        {
            // equivalent to this.FirstName = firstName
            // the class property is being set with the value from the parameter.
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public void BookFlight(Flight flight)
        {
            flight.BookedPassengers.Add(this);
            Console.WriteLine($"There are now {flight.BookedPassengers.Count} booked passengers.");
        }

        public bool CheckIn(Flight flight)
        {
            return flight.MovePassenger(this, flight.BookedPassengers, flight.CheckedInPassengers);
        }

        public bool BoardFlight(Flight flight)
        {
            return flight.MovePassenger(this, flight.CheckedInPassengers, flight.BoardedPassengers);
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        // Instead of printing FrequentFlyers.Passenger it will now print their full name.
        public override string ToString()
        {
            return FullName();
        }
    }
}