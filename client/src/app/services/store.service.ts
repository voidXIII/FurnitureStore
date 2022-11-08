import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../models/pagination';
import { IProductFunction } from '../models/productFunction';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { StoreParams } from '../models/storeParams';
import { IProduct } from '../models/product';
import { environment } from 'src/environments/environment';
import { IProductTopology } from '../models/productTopology';

@Injectable({
  providedIn: 'root'
})
export class StoreService {
  refresh: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getProducts(storeParams: StoreParams) {
    let params = new HttpParams();

    if (storeParams.topologyId !== 0) {
      params = params.append('topologyId', storeParams.topologyId.toString());
    }

    if (storeParams.functionId !== 0) {
      params = params.append('functionId', storeParams.functionId.toString());
    }

    if (storeParams.search){
      params = params.append('search', storeParams.search)
    }

    params = params.append('sort', storeParams.sort);
    params = params.append('pageIndex', storeParams.pageNumber.toString());
    params = params.append('pageSize', storeParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'products', { observe: 'response', params })
      .pipe(
        map(response => {
          return response.body;
        })
      )
  }

  getProduct(id: number){
    return this.http.get<IProduct>(this.baseUrl + 'products/' + id);
  }

  getFunctions() {
    return this.http.get<IProductFunction[]>(this.baseUrl + 'products/functions');
  }

  getTopologies() {
    return this.http.get<IProductTopology[]>(this.baseUrl + 'products/topologies');
  }

  addProduct(product: IProduct){
    return this.http.post<IProduct>(this.baseUrl + 'products', product);
  }

  updateProduct(id:number, product: FormData){
    return this.http.put<IProduct>(this.baseUrl + 'products/' + id, product)
  }

  deleteProduct(id: number){
    return this.http.delete(this.baseUrl + 'products?id=' + id);
  }

  setRefresh(value: boolean): void {
    this.refresh.next(value);
  }
}
