namespace TestClient.Models;

public class Flight
{
    public Guid Id { get; set; }

    public string Departure { get; set; }

    public string Destination { get; set; }

    public DateTime DepartureDateTime { get; set; }

    public DateTime ArrivalDateTime { get; set; }

    public int Capacity { get; set; }
}
