import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FlightService } from '../flight.service';
import { Flight } from '../flight-model';

@Component({
  selector: 'app-flight-details',
  templateUrl: './flight-details.component.html',
  styleUrls: ['./flight-details.component.scss'],
})
export class FlightDetailsComponent implements OnInit {
  flight!: Flight;

  constructor(
    private route: ActivatedRoute,
    private flightService: FlightService
  ) {}

  ngOnInit(): void {
    this.getFlightDetails();
  }

  getFlightDetails(): void {
    const id = this.route.snapshot.queryParamMap.get('id');
    console.log(id);
    if (id) {
      this.flightService
        .getFlightById(id)
        .subscribe((flight) => (this.flight = flight));
    }
  }
}
