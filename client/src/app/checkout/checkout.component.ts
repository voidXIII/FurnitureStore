import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IBasket } from '../models/basket';
import { BasketService } from '../services/basket.service';
import { CheckoutService } from '../services/checkout.service';
import { IOrder } from '../models/order';
import { NavigationExtras, Router } from '@angular/router';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {
  checkoutForm: FormGroup;
  
  constructor(private fb: FormBuilder, private basketService: BasketService, private checkoutService: CheckoutService, private snackBar: MatSnackBar,
    private router: Router) { }

  ngOnInit(): void {
    this.createCheckoutForm();
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

  submitOrder() {
    const basket = this.basketService.getCurrentBasketValue();
    const orderToCreate = this.getOrderToCreater(basket);
    this.checkoutService.createOrder(orderToCreate).subscribe((order: IOrder) => {
      this.snackBar.open('Order created successfully', 'Close', {
        duration: 5000
      });
      this.basketService.deleteBasketAfterOrder(basket.id);
      const navigationExtras: NavigationExtras = {state: order};
      this.router.navigate(['checkout/success'], navigationExtras);
    }, error => {
      this.snackBar.open(error.errors, 'Close', {
        duration: 5000
      });
    })
  }

  private getOrderToCreater(basket: IBasket) {
    return {
      basketId: basket.id,
      deliveryTypeId: + this.checkoutForm.get('deliveryForm').get('deliveryType').value,
      address: this.checkoutForm.get('addressForm').value
    };
  }

}
