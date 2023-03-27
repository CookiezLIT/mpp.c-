using MPP_Problema1.Model;
using SimpleSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP_Problema1.Service
{
    public class FlightService
    {
        private readonly IRepository<Flight> _flightRepository;

        public FlightService(IRepository<Flight> flightRepo)
        {
            this._flightRepository = flightRepo;
        }

        public List<Flight> GetFlights()
        {
            return _flightRepository.GetAllAsync().Result;
        }
    }
}
