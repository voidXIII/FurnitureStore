import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IRoom } from 'src/app/models/room';
import { BasketService } from 'src/app/services/basket.service';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-room-details',
  templateUrl: './room-details.component.html',
  styleUrls: ['./room-details.component.scss']
})
export class RoomDetailsComponent implements OnInit {
  room: IRoom;
  constructor(private bookService: BookService, private activateRoute: ActivatedRoute, private basketService: BasketService) { }

  ngOnInit(): void {
    this.activateRoute.paramMap.subscribe(response => {
      this.loadRoom(+response.get('id'))
    })
  }

  loadRoom(id:number){
    this.bookService.getRoom(id).subscribe(room => {
      this.room = room;
    }, error =>{
      console.log(error);
    });
  }

  addItemToBasket(){
    this.basketService.addItemToBasket(this.room);
  }
}
