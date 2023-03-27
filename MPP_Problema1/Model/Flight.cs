using Npgsql;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace MPP_Problema1.Model
{
    [Table("public.flight")]
    public class Flight
    {
        [Column("id")]
        public Guid Id { get; }

        [Column("departure")]
        public string Departure { get; }

        [Column("destination")]
        public string Destination { get; }

        [Column("departure_date_time")]
        public DateTime DepartureDateTime { get; }

        [Column("arrival_date_time")]
        public DateTime ArrivalDateTime { get; }

        [Column ("capacity")]
        public int Capacity { get; }
        public Flight(string departure, string destination, DateTime flightDate, DateTime flightTime, int capacity)
        {
            this.Id = Guid.NewGuid();
            this.Departure = departure;
            this.Destination = destination;
            this.DepartureDateTime = flightDate;
            this.ArrivalDateTime = flightTime;
            this.Capacity = capacity;
        }

        public Flight(Guid id, string departure, string destination, DateTime departureDateTime, DateTime arrivalDateTime, int capacity)
        {
            this.Id = id;
            this.Departure = departure;
            this.Destination = destination;
            this.DepartureDateTime = departureDateTime;
            this.ArrivalDateTime = arrivalDateTime;
            this.Capacity = capacity;
        }

        public Flight(object id, object departure, object destination, object departureDateTime, object arrivalDateTime, object capacity)
        {
            this.Id = (Guid)id;
            this.Departure = (string)departure;
            this.Destination = (string)destination;
            this.DepartureDateTime = (DateTime)departureDateTime;
            this.ArrivalDateTime = (DateTime)arrivalDateTime;
            this.Capacity = (int)capacity;

           
        }
    }
}
