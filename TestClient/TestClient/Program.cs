using System.Diagnostics.Metrics;
using System.Text;
using System.Text.Json;
using TestClient.Models;

namespace TestClient;

public class Program
{
    public static async Task Main(string[] args)
    {
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5000/api/flights/")
        };

        var jsonSerializerOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true, WriteIndented = true };

        #region GetAll
        Console.WriteLine("GetAll endpoint: ");
        var getAllResponse = await httpClient.GetAsync("");

        await ProcessGetResponse(getAllResponse, typeof(List<Flight>), jsonSerializerOptions);
        #endregion

        #region Create
        var createCommand = new CreateFlightCommand()
        {
            Departure = "Cluj",
            Destination = "Iasi",
            DepartureDateTime = DateTime.Now.AddDays(2),
            ArrivalDateTime = DateTime.Now.AddDays(3),
            Capacity = 150
        };

        Console.WriteLine();
        Console.WriteLine("Create endpoint: ");
        Console.WriteLine("CreateFlightCommand: ");
        Console.Write(JsonSerializer.Serialize(createCommand, typeof(CreateFlightCommand), jsonSerializerOptions));

        var createResponse = await httpClient.PostAsync("", new StringContent(JsonSerializer.Serialize(createCommand, typeof(CreateFlightCommand), jsonSerializerOptions),
                                                                              Encoding.UTF8,
                                                                              "application/json"));
        
        var createdFlightId = await ProcessPostResponse(createCommand, createResponse, typeof(Flight), jsonSerializerOptions);
        #endregion

        #region GetById
        Console.WriteLine();
        Console.WriteLine("GetById endpoint: ");

        var getByIdResponse = await httpClient.GetAsync(createdFlightId.ToString());

        await ProcessGetResponse(getByIdResponse, typeof(Flight), jsonSerializerOptions);
        #endregion

        #region Update
        Console.WriteLine();
        Console.WriteLine("Update endpoint: ");

        var updateCommand = new UpdateFlightCommand()
        {
            Id = createdFlightId,
            Departure = createCommand.Departure,
            Destination = createCommand.Destination,
            DepartureDateTime = createCommand.DepartureDateTime,
            ArrivalDateTime = createCommand.ArrivalDateTime,
            Capacity = 200
        };

        var updateResponse = await httpClient.PutAsync(updateCommand.Id.ToString(), new StringContent(JsonSerializer.Serialize(updateCommand, typeof(UpdateFlightCommand), jsonSerializerOptions),
                                                                              Encoding.UTF8,
                                                                              "application/json"));
        await ProcessPutResponse(updateCommand, updateResponse, typeof(Flight), jsonSerializerOptions);
        #endregion

        #region DeleteById

        Console.WriteLine();
        Console.WriteLine("Delete endpoint: ");

        var deleteResponse = await httpClient.DeleteAsync(createdFlightId.ToString());

        Console.WriteLine();
        Console.WriteLine($"Status code is: {deleteResponse.StatusCode}");
        Console.WriteLine("call get by id enpoint and try to get the deleted resource");

        var getDeletedResponse = await httpClient.GetAsync(createdFlightId.ToString());

        Console.WriteLine($"Status code is: {getDeletedResponse.StatusCode}");
        Console.WriteLine($"Message is: {await getDeletedResponse.Content.ReadAsStringAsync()}");

        #endregion

        Console.ReadLine();
    }

    public static async Task ProcessGetResponse(HttpResponseMessage response, Type serializationType, JsonSerializerOptions jsonSerializerOptions)
    {
        Console.WriteLine();
        Console.WriteLine($"Status code is: {response.StatusCode}");

        var responseMessage = await response.Content.ReadAsStringAsync();
        var obj = JsonSerializer.Deserialize(responseMessage, serializationType, jsonSerializerOptions);
        var consoleOutput = JsonSerializer.Serialize(obj, serializationType, jsonSerializerOptions);

        Console.WriteLine("Response is: ");
        Console.WriteLine();
        Console.Write(consoleOutput);
        Console.WriteLine();
    }

    public static async Task<Guid> ProcessPostResponse(CreateFlightCommand createFlightCommand, HttpResponseMessage response, Type serializationType, JsonSerializerOptions jsonSerializerOptions)
    {
        Console.WriteLine();
        Console.WriteLine($"Status code is: {response.StatusCode}");

        var responseMessage = await response.Content.ReadAsStringAsync();
        var obj = (Flight)JsonSerializer.Deserialize(responseMessage, serializationType, jsonSerializerOptions);
        var consoleOutput = JsonSerializer.Serialize(obj, serializationType, jsonSerializerOptions);

        Console.WriteLine("Response is: ");
        Console.Write(consoleOutput);
        Console.WriteLine();

        if(createFlightCommand.Destination == obj.Destination 
            && createFlightCommand.Departure == obj.Departure
            && createFlightCommand.DepartureDateTime == obj.DepartureDateTime
            && createFlightCommand.ArrivalDateTime == obj.ArrivalDateTime
            && createFlightCommand.Capacity == obj.Capacity)
        {
            Console.WriteLine("Created Flight matches the input CreateFlightCommand");
        }
        else
        {
            Console.WriteLine("CREATED FLIGHT DOES NOT MATCH INPUT FLIGHT");
        }
        Console.WriteLine();

        return obj.Id;
    }

    public static async Task ProcessPutResponse(UpdateFlightCommand updateFlightCommand, HttpResponseMessage response, Type serializationType, JsonSerializerOptions jsonSerializerOptions)
    {
        Console.WriteLine();
        Console.WriteLine($"Status code is: {response.StatusCode}");

        var responseMessage = await response.Content.ReadAsStringAsync();
        var obj = (Flight)JsonSerializer.Deserialize(responseMessage, serializationType, jsonSerializerOptions);
        var consoleOutput = JsonSerializer.Serialize(obj, serializationType, jsonSerializerOptions);

        Console.WriteLine("Response is: ");
        Console.Write(consoleOutput);
        Console.WriteLine();

        if (updateFlightCommand.Id == obj.Id
            && updateFlightCommand.Destination == obj.Destination
            && updateFlightCommand.Departure == obj.Departure
            && updateFlightCommand.DepartureDateTime == obj.DepartureDateTime
            && updateFlightCommand.ArrivalDateTime == obj.ArrivalDateTime
            && updateFlightCommand.Capacity == obj.Capacity)
        {
            Console.WriteLine("Updated Flight matches the input UpdateFlightCommand");
        }
        else
        {
            Console.WriteLine("UPDATED FLIGHT DOES NOT MATCH INPUT FLIGHT");
        }
        Console.WriteLine();
    }
}
