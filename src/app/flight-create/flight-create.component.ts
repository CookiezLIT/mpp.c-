import { Component } from '@angular/core';
import { FlightService } from '../flight.service';
import { Flight } from '../flight-model';

@Component({
  selector: 'app-flight-create',
  templateUrl: './flight-create.component.html',
  styleUrls: ['./flight-create.component.scss'],
})
export class FlightCreateComponent {
  flight: Flight = {
    id: '',
    departure: '',
    destination: '',
    departureDateTime: new Date(),
    arrivalDateTime: new Date(),
    capacity: 0,
  };

  constructor(private flightService: FlightService) {}

  createFlight(): void {
    this.flightService.createFlight(this.flight).subscribe((response) => {
      console.log(response);
      // Handle success or error response here
    });
  }
}
