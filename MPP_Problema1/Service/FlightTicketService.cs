using MPP_Problema1.Model;
using SimpleSql;
using System;

namespace MPP_Problema1.Service
{
    public class FlightTicketService
    {
        private readonly IRepository<Flight> _flightRepository;
        private readonly IRepository<FlightClient> _flightClientRepository;
        private readonly IRepository<FlightTicket> _flightTicketRepository;

        public FlightTicketService(IRepository<Flight> flightRepository,
                                   IRepository<FlightClient> flightClientRepository,
                                   IRepository<FlightTicket> flightTicketRepository)
        {
            _flightRepository = flightRepository;
            _flightClientRepository = flightClientRepository;
            _flightTicketRepository = flightTicketRepository;
        }

        public void BuyTicketForClient(Flight flight, string clientName, string clientAddress, string clientEmail)
        {
            //find flight with given destination and time 

            return;
        }
    }
}
