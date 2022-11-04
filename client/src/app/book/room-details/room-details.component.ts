import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { IRoom } from 'src/app/models/room';
import { BasketService } from 'src/app/services/basket.service';
import { BookService } from 'src/app/services/book.service';
import { RoomUpdateComponent } from '../room-update/room-update.component';

@Component({
  selector: 'app-room-details',
  templateUrl: './room-details.component.html',
  styleUrls: ['./room-details.component.scss']
})
export class RoomDetailsComponent implements OnInit {
  room: IRoom;
  constructor(private bookService: BookService, private activateRoute: ActivatedRoute, private basketService: BasketService, private dialog: MatDialog, 
    private router: Router, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.activateRoute.paramMap.subscribe(response => {
      this.loadRoom(+response.get('id'))
    })
  }

  loadRoom(id: number) {
    this.bookService.getRoom(id).subscribe(room => {
      this.room = room;
    }, error => {
      console.log(error);
    });
  }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.room);
  }

  updateRoom(room: IRoom) {
    this.dialog.open(RoomUpdateComponent, {
      data: {
        roomName: room.roomName,
        roomPrice: room.roomPrice,
        roomCapacity: room.roomCapacity,
        roomDescription: room.roomDescription
      }
    });
  }

  deleteRoom(id: number) {
    this.bookService.deleteRoom(id).subscribe(() => {
      this.bookService.setRefresh(true);
      this.router.navigateByUrl('/book');
      this.snackBar.open('Room was successfully deleted', 'Close', {
        duration: 5000
      });
    }, error => {
      console.log(error)
    });
  }
}
