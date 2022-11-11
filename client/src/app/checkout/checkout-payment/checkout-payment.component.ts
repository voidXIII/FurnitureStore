import { AfterViewInit, Component, ElementRef, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NavigationExtras, Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { IBasket } from 'src/app/models/basket';
import { IOrder } from 'src/app/models/order';
import { BasketService } from 'src/app/services/basket.service';
import { CheckoutService } from 'src/app/services/checkout.service';

declare var Stripe;

@Component({
  selector: 'app-checkout-payment',
  templateUrl: './checkout-payment.component.html',
  styleUrls: ['./checkout-payment.component.scss']
})
export class CheckoutPaymentComponent implements AfterViewInit, OnDestroy {
  @Input() checkoutForm: FormGroup;
  @ViewChild('cardNumber', { static: true }) cardNumberElement: ElementRef;
  @ViewChild('cardExpiry', { static: true }) cardExpiryElement: ElementRef;
  @ViewChild('cardCvc', { static: true }) cardCvcElement: ElementRef;

  stripe: any;
  cardNumber: any;
  cardExpiry: any;
  cardCvc: any;
  cardErrors: any;
  cardHandler = this.onChange.bind(this)
  cardNumberValid = false;

  constructor(private basketService: BasketService, private checkoutService: CheckoutService, private snackBar: MatSnackBar, private router: Router) { }


  ngAfterViewInit() {
    this.stripe = Stripe('pk_test_51M2D7yIYU5nUCBmp8LbP1Hou0nxTl169RQ8vBdpC5NgJbxTyC6d8oFWXz0awFUdtl9n70kAUN5YjaMBSbE3onjtw00FyVLA1zK');
    const elements = this.stripe.elements();

    this.cardNumber = elements.create('cardNumber');
    this.cardNumber.mount(this.cardNumberElement.nativeElement);
    this.cardNumber.addEventListener('change', this.cardHandler)

    this.cardExpiry = elements.create('cardExpiry');
    this.cardExpiry.mount(this.cardExpiryElement.nativeElement);
    this.cardExpiry.addEventListener('change', this.cardHandler)

    this.cardCvc = elements.create('cardCvc');
    this.cardCvc.mount(this.cardCvcElement.nativeElement);
    this.cardCvc.addEventListener('change', this.cardHandler)
  }

  ngOnDestroy() {
    this.cardNumber.destroy();
    this.cardExpiry.destroy();
    this.cardCvc.destroy();
  }

  onChange(event) {
    if (event.error) {
      this.cardErrors = event.error.message;
    } else {
      this.cardErrors = null;
    }

    switch(event.elementType) {
      case 'cardNumber':
        this.cardNumberValid = event.complete;
        break;
    }
  }

  public async submitOrder() {
    const basket = this.basketService.getCurrentBasketValue();
    try {
      const createdOrder = await this.createOrder(basket);
      const paymentResult = await this.confirmPaymentWithStripe(basket);

      if (paymentResult.paymentIntent) {
        this.basketService.deleteBasket(basket);
        const navigationExtras: NavigationExtras = { state: createdOrder };
        this.router.navigate(['checkout/success'], navigationExtras);
      } else {
        this.snackBar.open(paymentResult.error.message, 'Close', {
          duration: 5000
        });
      }
    } catch (error) {
      console.log(error)
    }

  }

  private async confirmPaymentWithStripe(basket) {
    return this.stripe.confirmCardPayment(basket.clientSecret, {
      payment_method: {
        card: this.cardNumber,
        billing_details: {
          name: this.checkoutForm.get('paymentForm').get('nameOnCard').value
        }
      }
    });
  }

  private async createOrder(basket: IBasket) {
    const orderToCreate = this.getOrderToCreater(basket);
    const createOrder = this.checkoutService.createOrder(orderToCreate)
    return lastValueFrom(createOrder);
  }

  private getOrderToCreater(basket: IBasket) {
    return {
      basketId: basket.id,
      deliveryTypeId: + this.checkoutForm.get('deliveryForm').get('deliveryType').value,
      address: this.checkoutForm.get('addressForm').value
    };
  }


}
