import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { StoreModule } from '../store/store.module';



@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    CarouselModule.forRoot(),
    StoreModule
  ],
  exports: [
    HomeComponent
  ]
})
export class HomeModule { }
