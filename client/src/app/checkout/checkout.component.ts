import {  Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BasketService } from '../services/basket.service';
import { CheckoutService } from '../services/checkout.service';
import { Router } from '@angular/router';
import { CheckoutPaymentComponent } from './checkout-payment/checkout-payment.component';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {
  checkoutForm: FormGroup;
  @ViewChild("paymentComponent") paymentComponent: CheckoutPaymentComponent;
  
  constructor(private fb: FormBuilder, private basketService: BasketService, private checkoutService: CheckoutService, private snackBar: MatSnackBar,
    private router: Router) { }

  ngOnInit(): void {
    this.createCheckoutForm();
    this.getDeliveryTypeValue();
  }


  createCheckoutForm() {
    this.checkoutForm = this.fb.group({
      addressForm: this.fb.group({
        firstName: [null, Validators.required],
        lastName: [null, Validators.required],
        country: [null, Validators.required],
        city: [null, Validators.required],
        street: [null, Validators.required],
        zipCode: [null, Validators.required],
      }),
      deliveryForm: this.fb.group({
        deliveryType: [null, Validators.required]
      }),
      paymentForm: this.fb.group({
        nameOnCard: [null, Validators.required]
      })
    })
  }

  submitOrder(){
    this.paymentComponent.submitOrder();
  }

  getDeliveryTypeValue() {
    const basket = this.basketService.getCurrentBasketValue();
    if (basket.deliveryTypeId !== null) {
      this.checkoutForm.get('deliveryForm').get('deliveryType').patchValue(basket.deliveryTypeId.toString());
    }
  }

  createStripePaymentIntent() {
    return this.basketService.createStripePaymentIntent().subscribe(() => {
      this.snackBar.open('Payment intent created successfully', 'Close', {
        duration: 5000
      });
    })
  }



}
