namespace RestApi.Models;

public class UpdateFlightCommand
{
    public Guid Id { get; init; }

    public string Departure { get; init; }

    public string Destination { get; init; }

    public DateTime DepartureDateTime { get; init; }

    public DateTime ArrivalDateTime { get; init; }

    public int Capacity { get; init; }
}
