using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPP_Problema1.Model
{
    [Table("flight_ticket")]
    public class FlightTicket
    {
        [Column("id")]
        public Guid Id { get; }

        [Column("client_id")]
        public Guid ClientId { get; }

        [Column("flight_id")]
        public Guid FlightId { get; }

        public FlightTicket(Guid id, Guid clientId, Guid flightId)
        {
            Id = id;
            ClientId = clientId;
            FlightId = flightId;
        }

        public FlightTicket(Guid clientId, Guid flightId)
        {
            Id = Guid.NewGuid();
            ClientId = clientId;
            FlightId = flightId;
        }

        public FlightTicket(object id, object clientId, object flightId)
        {
            Id = (Guid)id;
            ClientId = (Guid)clientId;
            FlightId = (Guid)flightId;
        }
    }
}
