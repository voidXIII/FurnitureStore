import { Component, OnInit } from '@angular/core';
import { IRoom } from './models/room';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'HotelBookingService';

  constructor() {}

  ngOnInit(): void {

  }
}
