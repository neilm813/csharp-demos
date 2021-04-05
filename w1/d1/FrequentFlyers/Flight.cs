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
    }
}