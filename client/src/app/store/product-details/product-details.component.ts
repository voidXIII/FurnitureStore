import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { IProduct } from 'src/app/models/product';
import { AccountService } from 'src/app/services/account.service';
import { BasketService } from 'src/app/services/basket.service';
import { StoreService } from 'src/app/services/store.service';
import { ProductUpdateComponent } from '../product-update/product-update.component';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  productId: number;
  quantity = 1;

  constructor(private storeService: StoreService, private activateRoute: ActivatedRoute, private basketService: BasketService, private dialog: MatDialog, 
    private router: Router, private snackBar: MatSnackBar, private accountService: AccountService) { }

  ngOnInit(): void {
    this.activateRoute.paramMap.subscribe(response => {
      this.productId = +response.get('id');
      this.loadProduct(+response.get('id'))
    })
  }

  loadProduct(id: number) {
    this.storeService.getProduct(id).subscribe(product => {
      this.product = product;
    }, error => {
      console.log(error);
    });
  }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.product, this.quantity);
  }

  incrementQuantity() {
    this.quantity++;
  }

  decrementQuantity() {
    if (this.quantity > 1) {
      this.quantity--;
    }
  }

  updateProduct(product: IProduct) {
    this.dialog.open(ProductUpdateComponent, {
      data: {
        id: this.productId,
        productName: product.productName,
        price: product.price,
        dimensions: product.dimensions,
        description: product.description
      }
    });
  }

  deleteProduct(id: number) {
    this.storeService.deleteProduct(id).subscribe(() => {
      this.storeService.setRefresh(true);
      this.router.navigateByUrl('/store');
      this.snackBar.open('Product was successfully deleted', 'Close', {
        duration: 5000
      });
    }, error => {
      console.log(error)
    });
  }

  isAdmin() {
    return this.accountService.isAdmin();
  }
}
