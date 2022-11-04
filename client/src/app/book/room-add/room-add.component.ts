import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';


@Component({
  selector: 'app-room-add',
  templateUrl: './room-add.component.html',
  styleUrls: ['./room-add.component.scss']
})
export class RoomAddComponent implements OnInit {
  roomAddForm: FormGroup;

  constructor(private bookService: BookService, private snackBar: MatSnackBar, private dialog: MatDialog, private router: Router) { }

  ngOnInit(): void {
    this.createRoomForm();
  }

  createRoomForm(){
    this.roomAddForm = new FormGroup({
      roomNumber: new FormControl('', [Validators.required]),
      roomName: new FormControl('', [Validators.required]),
      roomMainImageUrl: new FormControl('', [Validators.required]),
      roomPrice: new FormControl('', [Validators.required]),
      roomCapacity: new FormControl('', [Validators.required]),
      roomDescription: new FormControl('', [Validators.required])
    })
  }

  get roomNumber() { return this.roomAddForm.get('roomNumber'); }
  get roomName() { return this.roomAddForm.get('roomName'); }
  get roomMainImageUrl() { return this.roomAddForm.get('roomMainImageUrl'); }
  get roomPrice() { return this.roomAddForm.get('roomPrice'); }
  get roomCapacity() { return this.roomAddForm.get('roomCapacity'); }
  get roomDescription() { return this.roomAddForm.get('roomDescription'); }


  onSubmit(){
    const formData = new FormData();
    formData.append('roomNumber', this.roomNumber?.value);
    formData.append('roomName', this.roomName?.value);
    formData.append('roomMainImageUrl', this.roomMainImageUrl?.value);
    formData.append('roomPrice', this.roomPrice?.value);
    formData.append('roomCapacity', this.roomCapacity?.value);
    formData.append('roomDescription', this.roomDescription?.value);

    this.bookService.addRoom(formData).subscribe(() => {
      this.bookService.setRefresh(true);
      this.router.navigateByUrl('/book');
      this.snackBar.open('Room was successfully added', 'Close', {
        duration: 5000
      });
      this.dialog.closeAll();
    }, error => {
      console.log(error);
    });
    
  }

}
