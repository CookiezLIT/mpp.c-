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

        public Flight(string departure, string destination, DateTime flightDate, DateTime flightTime)
        {
            this.Id = Guid.NewGuid();
            this.Departure = departure;
            this.Destination = destination;
            this.DepartureDateTime = flightDate;
            this.ArrivalDateTime = flightTime;
        }

        public Flight(Guid id, string departure, string destination, DateTime flightDate, DateTime flightTime)
        {
            this.Id = id;
            this.Departure = departure;
            this.Destination = destination;
            this.DepartureDateTime = flightDate;
            this.ArrivalDateTime = flightTime;
        }

        public Flight(IDataReader reader)
        {
            this.Id = (Guid)reader["id"];
            this.Departure = (string)reader["departure"];
            this.Destination = (string)reader["destination"];
            this.DepartureDateTime = (DateTime)reader["departure_date_time"];
            this.ArrivalDateTime = (DateTime)reader["arrival_date_time"];
        }
    }
}
