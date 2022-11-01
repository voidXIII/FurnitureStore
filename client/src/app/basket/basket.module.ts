import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketComponent } from './basket.component';
import { BasketRoutingModule } from './basket-routing.module';
import { MatIconModule } from '@angular/material/icon'; 
import { SharedModule } from '../shared/shared.module';
import { MatButtonModule } from '@angular/material/button'; 


@NgModule({
  declarations: [
    BasketComponent
  ],
  imports: [
    CommonModule,
    BasketRoutingModule,
    MatIconModule,
    SharedModule,
    MatButtonModule
  ]
})
export class BasketModule { }
