import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IRoom } from 'src/app/models/room';
import { BookService } from 'src/app/_services/book.service';

@Component({
  selector: 'app-room-details',
  templateUrl: './room-details.component.html',
  styleUrls: ['./room-details.component.scss']
})
export class RoomDetailsComponent implements OnInit {
  room: IRoom;
  constructor(private bookService: BookService, private activateRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadRoom();
  }

  loadRoom(){
    this.bookService.getRoom(+ this.activateRoute.snapshot.paramMap.get('id')).subscribe(room => {
      this.room = room;
    }, error =>{
      console.log(error);
    });
  }
}
