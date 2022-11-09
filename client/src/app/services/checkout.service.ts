import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IDeliveryType } from '../models/deliveryType';
import { IOrderToCreate } from '../models/order';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  createOrder(order: IOrderToCreate) {
    return this.http.post(this.baseUrl + 'orders', order);
  }

  getDeliveryTypes(){
    return this.http.get(this.baseUrl + 'orders/deliveryTypes').pipe(
      map((deliveryTypes: IDeliveryType[]) => {
        return deliveryTypes.sort((a,b) => b.price - a.price);
      })
    )
      
  }
}
