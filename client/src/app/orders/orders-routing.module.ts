import { NgModule } from '@angular/core';
import { OrdersComponent } from './orders.component';
import { RouterModule, Routes } from '@angular/router';
import { OrdersDetailedComponent } from './orders-detailed/orders-detailed.component';

const routes: Routes = [
  {path: '', component: OrdersComponent},
  {path: ':id', component: OrdersDetailedComponent}
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class OrdersRoutingModule { }
