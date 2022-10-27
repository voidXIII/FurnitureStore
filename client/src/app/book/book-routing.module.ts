import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookComponent } from './book.component';
import { RoomDetailsComponent } from './room-details/room-details.component';

const routes: Routes = [
  { path: '', component: BookComponent },
  { path: ':id', component: RoomDetailsComponent }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports:[
    RouterModule
  ]
})
export class BookRoutingModule { }
