using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP_Problema1.Model
{
    internal class FlightTicket
    {
        
        public Guid Id { get; }

        public Guid ClientId { get; }

        public FlightClient Client { get; }

        public Guid FlightId { get; }
        public Flight Flight { get;  }

        

        public FlightTicket(FlightClient flight_client, Flight flight)
        {
            this.Id = Guid.NewGuid();
            this.Client = flight_client;
            this.Flight = flight;
        }


    }
}
