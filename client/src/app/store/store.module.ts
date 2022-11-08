import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreComponent } from './store.component';
import { ProductComponent } from './product/product.component';
import { SharedModule } from '../shared/shared.module';
import { PerDayPipe } from '../models/product';
import { MatSelectModule } from '@angular/material/select';
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatPaginatorModule } from '@angular/material/paginator';
import { ProductDetailsComponent } from './product-details/product-details.component'; 
import { StoreRoutingModule } from './store-routing.module';
import { ProductAddComponent } from './product-add/product-add.component';
import { MatSnackBarModule } from '@angular/material/snack-bar'; 
import { MatDialogModule } from '@angular/material/dialog'; 
import { ReactiveFormsModule } from '@angular/forms';
import { ProductUpdateComponent } from './product-update/product-update.component';


@NgModule({
  declarations: [
    StoreComponent,
    ProductComponent,
    PerDayPipe,
    ProductDetailsComponent,
    ProductAddComponent,
    ProductUpdateComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    MatSelectModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatButtonModule,
    MatPaginatorModule,
    StoreRoutingModule,
    MatSnackBarModule,
    MatDialogModule,
    ReactiveFormsModule
  ]
})
export class StoreModule { }
