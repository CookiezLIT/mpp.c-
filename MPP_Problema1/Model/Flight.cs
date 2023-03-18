using MPP_Problema1.Model;
using System;
using System.Reflection;

namespace MPP_Problema1.Model
{

    public class Flight
    {
        public Guid Id { get; }

        public string Departure { get; }
        public string Destination { get; }
        public DateTime FlightDate { get;  }
        public DateTime FlightTime { get; }

        public Flight(string departure, string destination, DateTime flightDate, DateTime flightTime)
        {
            this.Id = Guid.NewGuid();
            this.Departure = departure;
            this.Destination = destination;
            this.FlightDate = flightDate;
            this.FlightTime = flightTime;
        }
    }
}
