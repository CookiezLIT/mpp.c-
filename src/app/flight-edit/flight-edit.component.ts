import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Flight } from '../flight-model';
import { FlightService } from '../flight.service';

@Component({
  selector: 'app-flight-edit',
  templateUrl: './flight-edit.component.html',
  styleUrls: ['./flight-edit.component.scss'],
})
export class FlightEditComponent implements OnInit {
  flight: Flight = {
    id: '',
    departure: '',
    destination: '',
    departureDateTime: new Date(),
    arrivalDateTime: new Date(),
    capacity: 0,
  };

  constructor(
    private route: ActivatedRoute,
    private flightService: FlightService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getFlight();
  }

  getFlight(): void {
    const id = this.route.snapshot.queryParamMap.get('id');
    console.log(id);
    if (id) {
      this.flightService
        .getFlightById(id)
        .subscribe((flight) => (this.flight = flight));
    }
  }

  saveFlight(): void {
    this.flightService.updateFlight(this.flight).subscribe(() => this.goBack());
  }

  goBack(): void {
    this.location.back();
  }
}
