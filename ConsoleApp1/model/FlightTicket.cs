using model;

namespace ConsoleApp1.model;

public class FlightTicket : Entity<int>
{

    private FlightClient flight_client { get; set; }
    private Flight flight { get; set; }

    public FlightTicket(FlightClient flightClient, Flight flight)
    {
        flight_client = flightClient;
        this.flight = flight;
    }
}