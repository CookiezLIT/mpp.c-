using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly FlightContext _context;

        public FlightsController(FlightContext context)
        {
            _context = context;
        }

        // GET: api/Flights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
        {
          if (_context.Flights == null)
          {
              return NotFound();
          }
            return await _context.Flights.ToListAsync();
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlight(Guid id)
        {
            if (_context.Flights == null)
            {
                return NotFound();
            }
            var flight = await _context.Flights.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            return flight;
        }

        // PUT: api/Flights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlight([FromRoute] Guid id, [FromBody] UpdateFlightCommand updateFlightCommand)
        {
            if (id != updateFlightCommand.Id)
            {
                return BadRequest();
            }

            var flight = new Flight()
            {
                Id = id,
                Departure = updateFlightCommand.Departure,
                Destination = updateFlightCommand.Destination,
                DepartureDateTime = updateFlightCommand.DepartureDateTime,
                ArrivalDateTime = updateFlightCommand.ArrivalDateTime,
                Capacity =  updateFlightCommand.Capacity
            };

            _context.Entry(flight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(flight);
        }

        // POST: api/Flights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Flight>> PostFlight(CreateFlightCommand createFlightCommand)
        {
            if (_context.Flights == null)
            {
                return Problem("Entity set 'FlightContext.Flights'  is null.");
            }

            var flight = new Flight()
            {
                Id = Guid.NewGuid(),
                Departure = createFlightCommand.Departure,
                Destination = createFlightCommand.Destination,
                DepartureDateTime = createFlightCommand.DepartureDateTime,
                ArrivalDateTime = createFlightCommand.ArrivalDateTime,
                Capacity = createFlightCommand.Capacity
            };

            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlight", new { id = flight.Id }, flight);
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(Guid id)
        {
            if (_context.Flights == null)
            {
                return NotFound();
            }
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            //_context.Flights.Remove(flight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightExists(Guid id)
        {
            return (_context.Flights?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
