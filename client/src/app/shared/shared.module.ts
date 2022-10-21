import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagingHeaderComponent } from './paging-header/paging-header.component';
import { PagingComponent } from './paging/paging.component';
import {MatPaginatorModule} from '@angular/material/paginator'; 


@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagingComponent
  ],
  imports: [
    CommonModule,
    MatPaginatorModule
  ],
  exports: [
    PagingHeaderComponent,
    PagingComponent
  ]
})
export class SharedModule { }
