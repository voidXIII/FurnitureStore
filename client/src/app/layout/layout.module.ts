import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavTopBarComponent } from './nav-top-bar/nav-top-bar.component';



@NgModule({
  declarations: [
    NavTopBarComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    NavTopBarComponent
  ]
})
export class LayoutModule { }
