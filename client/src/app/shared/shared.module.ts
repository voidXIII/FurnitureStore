import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagingHeaderComponent } from './paging-header/paging-header.component';
import { PagingComponent } from './paging/paging.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { TextInputComponent } from './text-input/text-input.component';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { TestErrorComponent } from './test-error/test-error.component';
import { MatButtonModule } from '@angular/material/button';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { OrderTotalsComponent } from './order-totals/order-totals.component';

@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagingComponent,
    TextInputComponent,
    TestErrorComponent,
    NotFoundComponent,
    ServerErrorComponent,
    OrderTotalsComponent
  ],
  imports: [
    CommonModule,
    MatPaginatorModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatSnackBarModule
  ],
  exports: [
    PagingHeaderComponent,
    PagingComponent,
    TextInputComponent,
    OrderTotalsComponent
  ]
})
export class SharedModule { }
