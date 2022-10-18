import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Employee } from './component-test/model';
import { IRoom } from './models/room';
import { IPagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'HotelBookingService';
  rooms: IRoom[];
  employees: Employee[] = [
    { empCode: 1, empName: 'Andrew' },
    { empCode: 2, empName: 'Jana' },
    { empCode: 3, empName: 'Mary' },
    { empCode: 4, empName: 'Teo' },
    { empCode: 5, empName: 'John' },
  ]

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/rooms?pageSize=50').subscribe((response: IPagination) => {
      console.log(response);
      this.rooms = response.data;
    }, error =>{
      console.log(error)
    });
  }
}
