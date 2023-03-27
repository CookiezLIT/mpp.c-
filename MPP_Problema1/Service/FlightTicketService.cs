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

        public bool BuyTicketForClient(Guid flight_id, string clientName, string clientAddress, string clientEmail)
        {

            //find flight with given destination and time 
            Flight flight = _flightRepository.GetAsync(flight_id);

            if (flight == null)
            {
                return false;
            }

            //save client to the repo
            FlightClient client = new FlightClient(clientName, clientAddress, clientEmail);

            _flightClientRepository.CreateAsync(client);
            
            //save the ticket to the repo
            FlightTicket ticket = new FlightTicket(client.Id, flight.Id);

            _flightTicketRepository.CreateAsync(ticket);

            //update the flight capacity
            flight.Capacity = flight.Capacity - 1;
            _flightRepository.UpdateAsync(flight);

            return true;
        }
    }
}
