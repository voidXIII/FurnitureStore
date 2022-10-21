import { Component, Input, OnInit } from '@angular/core';
import { IRoom } from 'src/app/models/room';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.scss']
})
export class RoomComponent implements OnInit {
  @Input() room: IRoom;
  constructor() { }

  ngOnInit(): void {
  }

}
