import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavTopBarComponent } from './nav-top-bar/nav-top-bar.component';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { RouterModule } from '@angular/router';
import { MatBadgeModule } from '@angular/material/badge';
import { MatMenuModule } from '@angular/material/menu';
import { MatDialogModule } from '@angular/material/dialog';


@NgModule({
  declarations: [
    NavTopBarComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
    MatButtonModule,
    RouterModule,
    MatBadgeModule,
    MatMenuModule,
    MatDialogModule
  ],
  exports: [
    NavTopBarComponent
  ]
})
export class LayoutModule { }
