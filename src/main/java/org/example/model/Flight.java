package org.example.model;

public class Flight{


    private String id;
    private String departure;
    private String destination;

    private String arrivalDateTime;

    private String departureDateTime;

    private int capacity;

//    public Flight(String id, String departure, String destination, String flight_date, String flight_time, int capacity) {
//        this.id=id;
//        this.departure = departure;
//        this.destination = destination;
//        this.flight_date = flight_date;
//        this.flight_time = flight_time;
//        this.capacity = capacity;
//    }

    public String getDeparture() {
        return departure;
    }

    public void setDeparture(String departure) {
        this.departure = departure;
    }

    public String getDestination() {
        return destination;
    }

    public void setDestination(String destination) {
        this.destination = destination;
    }



    public int getCapacity() {
        return capacity;
    }

    public void setCapacity(int capacity) {
        this.capacity = capacity;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getArrivalDateTime() {
        return arrivalDateTime;
    }

    public void setArrivalDateTime(String arrivalDateTime) {
        this.arrivalDateTime = arrivalDateTime;
    }

    public String getDepartureDateTime() {
        return departureDateTime;
    }

    public void setDepartureDateTime(String departureDateTime) {
        this.departureDateTime = departureDateTime;
    }

    @Override
    public String toString() {
        return "Flight{" +
                ", departure='" + departure + '\'' +
                ", destination='" + destination + '\'' +
                ", flight_date=" + arrivalDateTime +
                ", flight_time=" + departureDateTime +
                ", capacity=" + capacity +
                '}';
    }
}