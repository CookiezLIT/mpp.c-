package org.example;

import com.fasterxml.jackson.databind.ObjectMapper;
import org.example.model.Flight;

import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.time.Duration;



public class Main {


    public static void main(String[] args) throws URISyntaxException, IOException, InterruptedException {


        String BaseUrl = "http://localhost:5000/api";
        //TrustAllManager.disableCertificateValidation();
        get_all_flights(BaseUrl);
        get_one_flight(BaseUrl);
        post_one_flight(BaseUrl);
        delete_one_flight(BaseUrl);
        put_one_flight(BaseUrl);
    }

    public static void get_all_flights(String BaseUrl) throws URISyntaxException, IOException, InterruptedException {


        // send the request
        URI targetURI = new URI(BaseUrl + "/Flights");
        HttpRequest httpRequest = HttpRequest.newBuilder()
                .uri(targetURI)
                .GET()
                .build();

        HttpClient httpClient = HttpClient.newHttpClient();
        HttpResponse<String> response = httpClient.send(httpRequest, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.statusCode());


        //map the response to JSON object
        ObjectMapper objectMapper = new ObjectMapper();
        Flight[] flights = objectMapper.readValue(response.body(), Flight[].class);
        System.out.println("-------------------------------------------------");
        System.out.println("GET ALL FLIGHTS:");
        System.out.println("total flights : "+flights.length);

    }

    public static void get_one_flight(String BaseUrl) throws URISyntaxException, IOException, InterruptedException {
        // send the request
        URI targetURI = new URI(BaseUrl + "/Flights/81ed268c-bc51-4a77-94f3-51e3689ed4f3");
        HttpRequest httpRequest = HttpRequest.newBuilder()
                .uri(targetURI)
                .GET()
                .build();

        HttpClient httpClient = HttpClient.newHttpClient();
        HttpResponse<String> response = httpClient.send(httpRequest, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.statusCode());


        //map the response to JSON object
        ObjectMapper objectMapper = new ObjectMapper();
        Flight flight = objectMapper.readValue(response.body(), Flight.class);

        System.out.println("-------------------------------------------------");
        System.out.println("GET ONE FLIGHT:");
        System.out.println(flight);
    }

    public static void post_one_flight(String requestUrl) throws URISyntaxException, IOException, InterruptedException {
        // Create a Flight object with the necessary data
        Flight flight = new Flight();
        flight.setId("FL123");
        flight.setDeparture("New York");
        flight.setDestination("London");
        flight.setDepartureDateTime("2023-05-18T10:00:00");
        flight.setArrivalDateTime("2023-05-18T16:00:00");
        flight.setCapacity(100);

        // Convert the Flight object to JSON
        String jsonPayload = "{\"id\":\"" + flight.getId() + "\","
                + "\"departure\":\"" + flight.getDeparture() + "\","
                + "\"destination\":\"" + flight.getDestination() + "\","
                + "\"departureDateTime\":\"" + flight.getDepartureDateTime() + "\","
                + "\"arrivalDateTime\":\"" + flight.getArrivalDateTime() + "\","
                + "\"capacity\":" + flight.getCapacity() + "}";

        String contentType = "application/json";


        HttpClient httpClient = HttpClient.newBuilder()
                .connectTimeout(Duration.ofSeconds(10))
                .build();

        HttpRequest request = HttpRequest.newBuilder()
                .uri(new URI(requestUrl + "/Flights"))
                .timeout(Duration.ofSeconds(10))
                .header("Content-Type", contentType)
                .POST(HttpRequest.BodyPublishers.ofString(jsonPayload))
                .build();

        HttpResponse<String> response = httpClient.send(request, HttpResponse.BodyHandlers.ofString());

        int statusCode = response.statusCode();
        String responseBody = response.body();


        System.out.println("-------------------------------------------------");
        System.out.println("POST REQUEST:");
        System.out.println("Status Code: " + statusCode);
        System.out.println("Response Body: " + responseBody);
    }

    public static void put_one_flight(String requestUrl) throws IOException, InterruptedException, URISyntaxException {
        Flight flight = new Flight();
        flight.setId("e3bdd0af-eecf-4f41-8e63-73ccb2b0d4ec");
        flight.setDeparture("New York");
        flight.setDestination("London");
        flight.setDepartureDateTime("2023-05-18T10:00:00");
        flight.setArrivalDateTime("2023-05-18T16:00:00");
        flight.setCapacity(120);

        // Convert the Flight object to JSON
        String jsonPayload = "{\"id\":\"" + flight.getId() + "\","
                + "\"departure\":\"" + flight.getDeparture() + "\","
                + "\"destination\":\"" + flight.getDestination() + "\","
                + "\"departureDateTime\":\"" + flight.getDepartureDateTime() + "\","
                + "\"arrivalDateTime\":\"" + flight.getArrivalDateTime() + "\","
                + "\"capacity\":" + flight.getCapacity() + "}";

        String contentType = "application/json";

        HttpClient httpClient = HttpClient.newBuilder()
                .connectTimeout(Duration.ofSeconds(10))
                .build();

        HttpRequest request = HttpRequest.newBuilder()
                .uri(new URI(requestUrl + "/Flights/e3bdd0af-eecf-4f41-8e63-73ccb2b0d4ec"))
                .timeout(Duration.ofSeconds(10))
                .header("Content-Type", contentType)
                .PUT(HttpRequest.BodyPublishers.ofString(jsonPayload))
                .build();

        HttpResponse<String> response = httpClient.send(request, HttpResponse.BodyHandlers.ofString());

        int statusCode = response.statusCode();
        String responseBody = response.body();

        System.out.println("-------------------------------------------------");
        System.out.println("PUT REQUEST:");
        System.out.println("Status Code: " + statusCode);
        System.out.println("Response Body: " + responseBody);
    }

    public static void delete_one_flight(String BaseUrl) throws URISyntaxException, IOException, InterruptedException {

        // send the request
        URI targetURI = new URI(BaseUrl + "/Flights/3f1951e2-be2e-4e00-83cb-d57ffa134d75");
        HttpRequest httpRequest = HttpRequest.newBuilder()
                .uri(targetURI)
                .DELETE()
                .build();

        HttpClient httpClient = HttpClient.newHttpClient();
        HttpResponse<String> response = httpClient.send(httpRequest, HttpResponse.BodyHandlers.ofString());


        System.out.println("-------------------------------------------------");
        System.out.println("FLIGHT DELETION RESPONSE:");
        System.out.println(response.statusCode());
    }
}