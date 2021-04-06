using System;
using System.Collections.Generic;

namespace FrequentFlyers
{
    public class Flight
    {
        public string FlightId { get; set; }
        public string DepartureGate { get; set; }
        public string ArrivalGate { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        // Booked Passengers have not checked in or boarded.
        public List<Passenger> BookedPassengers { get; set; } = new List<Passenger>();
        public List<Passenger> CheckedInPassengers { get; set; } = new List<Passenger>();
        public List<Passenger> BoardedPassengers { get; set; } = new List<Passenger>();

        public Flight(string flightId, string departureGate, string arrivalGate, string origin, string destination, DateTime departure, DateTime arrival)
        {
            FlightId = flightId;
            DepartureGate = departureGate;
            ArrivalGate = arrivalGate;
            Origin = origin;
            Destination = destination;
            Departure = departure;
            Arrival = arrival;
        }

        public TimeSpan Duration()
        {
            return Arrival - Departure;
        }

        public bool MovePassenger(Passenger passenger, List<Passenger> from, List<Passenger> to)
        {
            int idx = from.IndexOf(passenger);

            if (idx == -1)
            {
                return false;
            }

            from.RemoveAt(idx);
            to.Add(passenger);
            return true;
        }

        // If BookedPassengers was private, it could only be changed from within the class so we would have to provide a public method like this to allow it to be changed from outside the class.
        public void BookFlight(Passenger passenger)
        {
            BookedPassengers.Add(passenger);
            Console.WriteLine($"There are now {BookedPassengers.Count} booked passengers.");
        }

        public string ManifestAll()
        {
            string manifestReport = "\nBookings:\n";

            for (int i = 0; i < BookedPassengers.Count; i++)
            {
                manifestReport += $"{i + 1}: {BookedPassengers[i].FullName()}\n";
            }

            manifestReport += "\nChecked Ins:\n";

            for (int i = 0; i < CheckedInPassengers.Count; i++)
            {
                manifestReport += $"{i + 1}: {CheckedInPassengers[i].FullName()}\n";
            }

            manifestReport += "\nBoarded Passengers:\n";

            for (int i = 0; i < BoardedPassengers.Count; i++)
            {
                manifestReport += $"{i + 1}: {BoardedPassengers[i].FullName()}\n";
            }

            return manifestReport;
        }

        public Dictionary<string, List<string>> CategorizeBoardedPassengersByLastName()
        {
            /* 
                Smith:
                    John Smith, Jane Smith, Joe Smith
                Pierce:
                    Amy Pierce
                Myers:
                    Merton Myers, Mike Myers
            */

            // DataType                      varName    = starting value
            Dictionary<string, List<string>> categories = new Dictionary<string, List<string>>();

            foreach (Passenger passenger in BoardedPassengers)
            {
                if (categories.ContainsKey(passenger.LastName))
                {
                    // categories["keyName"] <- that retrieves the value which is a list
                    categories[passenger.LastName].Add(passenger.FullName());
                }
                else
                {
                    // First time finding a passenger with this last name, instantiate and add items at same time.
                    List<string> initialList = new List<string>
                    {
                        passenger.FullName()
                    };

                    categories.Add(passenger.LastName, initialList);
                }
            }

            return categories;
        }
    }
}