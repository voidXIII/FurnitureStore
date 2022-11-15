import { Component, OnInit } from '@angular/core';
import { IProduct } from '../models/product';
import { HomePageStoreParams, StoreParams } from '../models/storeParams';
import { StoreService } from '../services/store.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  products: IProduct[];
  storeParams = new HomePageStoreParams();
  totalCount: number = 4;


  constructor(private storeService: StoreService) { }

  ngOnInit(): void {
    this.GetProducts();
  }


  GetProducts() {
    this.storeService.getProducts(this.storeParams).subscribe(response => {
      this.products = response.data;
      console.log(this.products);
    });
  }


  

}
