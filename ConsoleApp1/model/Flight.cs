using model;

namespace ConsoleApp1.model;

public class Flight : Entity<int>
{
    private string departure { get; set; }
    private string destination { get; set; }
    private DateTime flight_date { get; set; }
    private DateTime flight_time { get; set; }

    public Flight(int id, string departure, string destination, DateTime flightDate, DateTime flightTime)
    {
        this.id = id;
        this.departure = departure;
        this.destination = destination;
        flight_date = flightDate;
        flight_time = flightTime;
    }
}