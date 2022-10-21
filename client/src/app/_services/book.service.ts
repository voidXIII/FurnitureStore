import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../models/pagination';
import { IRoomType } from '../models/roomType';
import { map } from 'rxjs';
import { BookParams } from '../models/bookParams';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getRooms(bookParams: BookParams) {
    let params = new HttpParams();

    if (bookParams.typeId !== 0) {
      params = params.append('typeId', bookParams.typeId.toString());
    }

    if (bookParams.search){
      params = params.append('search', bookParams.search)
    }

    params = params.append('sort', bookParams.sort);
    params = params.append('pageIndex', bookParams.pageNumber.toString());
    params = params.append('pageSize', bookParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + "rooms", { observe: 'response', params })
      .pipe(
        map(response => {
          return response.body;
        })
      )
  }

  getTypes() {
    return this.http.get<IRoomType[]>(this.baseUrl + "rooms/types");
  }
}
