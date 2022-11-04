import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IRoom } from 'src/app/models/room';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-room-update',
  templateUrl: './room-update.component.html',
  styleUrls: ['./room-update.component.scss']
})
export class RoomUpdateComponent implements OnInit {
  room: IRoom;
  roomUpdateForm: FormGroup;

  constructor(@Inject(MAT_DIALOG_DATA) public data: IRoom, private bookService: BookService, private snackBar: MatSnackBar, private dialog: MatDialog) {
   }
    
  ngOnInit(): void {
    this.loadRoom();
    this.updateRoomForm();
  }
  get roomName() { return this.roomUpdateForm.get('roomName'); }
  get roomPrice() { return this.roomUpdateForm.get('roomPrice'); }
  get roomCapacity() { return this.roomUpdateForm.get('roomCapacity'); }
  get roomDescription() { return this.roomUpdateForm.get('roomDescription'); }

  
  loadRoom(){
    this.bookService.getRoom(this.data.id).subscribe(response => {
      this.room = response;
      this.updateRoomForm();
    }, error => {
      console.log(error);
    })
  }

  updateRoomForm(){
    this.roomUpdateForm = new FormGroup({
      roomName: new FormControl(this.room?.roomName, [Validators.required]),
      roomPrice: new FormControl(this.room?.roomPrice, [Validators.required]),
      roomCapacity: new FormControl(this.room?.roomCapacity, [Validators.required]),
      roomDescription: new FormControl(this.room?.roomDescription, [Validators.required])
    })
  }




  onSubmit(id: number){
    const formData = new FormData();
    formData.append('roomName', this.roomName?.value);
    formData.append('roomPrice', this.roomPrice?.value);
    formData.append('roomCapacity', this.roomCapacity?.value);
    formData.append('roomDescription', this.roomDescription?.value);

    this.bookService.updateRoom(id, formData).subscribe(response => {
      this.snackBar.open('Room was successfully updated', 'Close', {
        duration: 5000
      });
      this.dialog.closeAll();
    }, error => {
      console.log(error);
    });
  }

}
