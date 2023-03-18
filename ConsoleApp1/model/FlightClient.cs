using model;

namespace ConsoleApp1.model;


public class FlightClient : Entity<int>
{
    private string name { get; set; }
    private string address { get; set; }
    private string email { get; set; }
    
    public FlightClient(int id, string name, string address, string email)
    {
        this.id = id;
        this.name = name;
        this.address = address;
        this.email = email;
    }
}