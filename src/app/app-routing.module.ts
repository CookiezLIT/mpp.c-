import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FlightListComponent } from './flight-list/flight-list.component';
import { FlightDetailsComponent } from './flight-details/flight-details.component';
import { FlightCreateComponent } from './flight-create/flight-create.component';
import { FlightEditComponent } from './flight-edit/flight-edit.component';

const routes: Routes = [
  { path: 'get_flights', component: FlightListComponent },
  { path: 'get_flight', component: FlightDetailsComponent },
  { path: 'add_flight', component: FlightCreateComponent },
  { path: 'edit_flight', component: FlightEditComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
