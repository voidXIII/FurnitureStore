import { Component, OnInit } from '@angular/core';
import { IOrder } from '../models/order';
import { OrdersService } from '../services/orders.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {
  orders: IOrder[];

  constructor(private orderService: OrdersService) { }

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders() {
    this.orderService.getUserOrders().subscribe((orders: IOrder[]) => {
      this.orders = orders;
    }, error => {
      console.log(error);
    })
  }

}
