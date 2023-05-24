namespace RestApi.Models;

public class CreateFlightCommand
{
    public string Departure { get; init; }

    public string Destination { get; init; }

    public DateTime DepartureDateTime { get; init; }

    public DateTime ArrivalDateTime { get; init; }

    public int Capacity { get; init; }
}
