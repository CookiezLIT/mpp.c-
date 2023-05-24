import { Component, OnInit } from '@angular/core';
import { Flight } from '../flight-model';
import { FlightService } from '../flight.service';

@Component({
  selector: 'app-flight-list',
  templateUrl: './flight-list.component.html',
  styleUrls: ['./flight-list.component.scss'],
})
export class FlightListComponent implements OnInit {
  flights: Flight[] = [];

  constructor(private flightService: FlightService) {}

  ngOnInit() {
    this.getFlights();
  }

  getFlights(): void {
    this.flightService
      .getFlights()
      .subscribe((flights) => (this.flights = flights));
  }

  deleteFlight(id: string): void {
    this.flightService.deleteFlight(id)
      .subscribe(() => {
        // Remove the deleted flight from the list
        this.flights = this.flights.filter(flight => flight.id !== id);
      });
  }
}
