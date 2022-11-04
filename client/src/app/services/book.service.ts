import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../models/pagination';
import { IRoomType } from '../models/roomType';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { BookParams } from '../models/bookParams';
import { IRoom } from '../models/room';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  refresh: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  baseUrl = environment.apiUrl;

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

    return this.http.get<IPagination>(this.baseUrl + 'rooms', { observe: 'response', params })
      .pipe(
        map(response => {
          return response.body;
        })
      )
  }

  getRoom(id: number){
    return this.http.get<IRoom>(this.baseUrl + 'rooms/' + id);
  }

  getTypes() {
    return this.http.get<IRoomType[]>(this.baseUrl + 'rooms/types');
  }

  addRoom(room: FormData){
    return this.http.post<IRoom>(this.baseUrl + 'rooms', room);
  }

  updateRoom(id:number, room: FormData){
    return this.http.put<IRoom>(this.baseUrl + 'rooms/' + id, room)
  }

  deleteRoom(id: number){
    return this.http.delete(this.baseUrl + 'rooms?id=' + id);
  }

  setRefresh(value: boolean): void {
    this.refresh.next(value);
  }
}
