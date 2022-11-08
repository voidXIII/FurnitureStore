import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { StoreParams } from '../models/storeParams';
import { IProduct } from '../models/product';
import { IProductFunction } from '../models/productFunction';
import { StoreService } from '../services/store.service';
import { ProductAddComponent } from './product-add/product-add.component';
import { IProductTopology } from '../models/productTopology';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.scss']
})
export class StoreComponent implements OnInit {
  @ViewChild('search') searchTerm: ElementRef;
  products: IProduct[];
  topologies: IProductTopology[];
  functions: IProductFunction[];
  storeParams = new StoreParams();
  totalCount: number = 0;
  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'}
  ];

  constructor(private storeService: StoreService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.GetProducts();
    this.GetFunctions();
    this.GetTopologies();
  }

  GetProducts() {
    this.storeService.getProducts(this.storeParams).subscribe(response => {
      this.products = response.data;
      this.storeParams.pageNumber = response.pageIndex;
      this.storeParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    });
    ;
  }

  GetFunctions() {
    this.storeService.getFunctions().subscribe(response => {
      this.functions = [{id:0, functionTitle:'All'}, ...response];
      console.log(response);
    })
  }

  GetTopologies() {
    this.storeService.getTopologies().subscribe(response => {
      this.topologies = [{id:0, topologyTitle:'All'}, ...response];
    })
  }

  OnFunctionSelected(functionId: number){
    this.storeParams.functionId = functionId;
    this.storeParams.pageNumber = 0;
    this.GetProducts();
  }

  OnTopologySelected(topologyId: number){
    this.storeParams.topologyId = topologyId;
    this.storeParams.pageNumber = 0;
    this.GetProducts();
  }

  OnSortSelected(sort: string){
    this.storeParams.sort = sort;
    this.GetProducts();
  }

  OnPageChanged(event: PageEvent){
    this.storeParams.pageNumber = event.pageIndex;
    this.storeParams.pageSize = event.pageSize;
    this.totalCount = event.length;
    this.GetProducts();
  }

  OnSearch(){
    this.storeParams.search = this.searchTerm.nativeElement.value;
    this.GetProducts();
  }

  OnReset(){
    this.searchTerm.nativeElement.value = '';
    this.storeParams = new StoreParams();
    this.GetProducts();
  }

  addProduct(){
    this.dialog.open(ProductAddComponent);
  }

}
