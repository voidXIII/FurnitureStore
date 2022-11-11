import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IOrder } from 'src/app/models/order';
import { OrdersService } from 'src/app/services/orders.service';

@Component({
  selector: 'app-orders-detailed',
  templateUrl: './orders-detailed.component.html',
  styleUrls: ['./orders-detailed.component.scss']
})
export class OrdersDetailedComponent implements OnInit {
  order: IOrder;

  constructor() { }

  ngOnInit(): void {
  }

}
