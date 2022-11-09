import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { IDeliveryType } from 'src/app/models/deliveryType';
import { BasketService } from 'src/app/services/basket.service';
import { CheckoutService } from 'src/app/services/checkout.service';

@Component({
  selector: 'app-checkout-delivery',
  templateUrl: './checkout-delivery.component.html',
  styleUrls: ['./checkout-delivery.component.scss']
})
export class CheckoutDeliveryComponent implements OnInit {
  @Input() checkoutForm: FormGroup;
  deliveryTypes: IDeliveryType[];

  constructor(private checkoutService: CheckoutService, private basketService: BasketService) { }

  ngOnInit(): void {
    this.checkoutService.getDeliveryTypes().subscribe((dTypes: IDeliveryType[]) => {
      this.deliveryTypes = dTypes;
    })
  }

  setDeliveryPrice(deliveryType: IDeliveryType){
    this.basketService.setDeliveryPice(deliveryType);
  }

}
