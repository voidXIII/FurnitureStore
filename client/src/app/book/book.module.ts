import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookComponent } from './book.component';
import { RoomComponent } from './room/room.component';
import { SharedModule } from '../shared/shared.module';
import { PerDayPipe } from '../models/room';
import { MatSelectModule } from '@angular/material/select';
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator'; 


@NgModule({
  declarations: [
    BookComponent,
    RoomComponent,
    PerDayPipe
  ],
  imports: [
    CommonModule,
    SharedModule,
    MatSelectModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatButtonModule,
    MatPaginatorModule
  ],
  exports: [
    BookComponent
  ]
})
export class BookModule { }
