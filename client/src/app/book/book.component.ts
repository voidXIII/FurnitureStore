import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { BookParams } from '../models/bookParams';
import { IRoom } from '../models/room';
import { IRoomType } from '../models/roomType';
import { BookService } from '../services/book.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})
export class BookComponent implements OnInit {
  @ViewChild('search') searchTerm: ElementRef;
  rooms: IRoom[];
  types: IRoomType[];
  bookParams = new BookParams();
  totalCount: number = 0;
  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'}
  ];

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    this.GetProducts();
    this.GetTypes();
  }

  GetProducts() {
    this.bookService.getRooms(this.bookParams).subscribe(response => {
      this.rooms = response.data;
      this.bookParams.pageNumber = response.pageIndex;
      this.bookParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    });
    ;
  }

  GetTypes() {
    this.bookService.getTypes().subscribe(response => {
      this.types = [{id:0, roomTypeName:'All'}, ...response];
    })
  }

  OnTypeSelected(typeId: number){
    this.bookParams.typeId = typeId;
    this.bookParams.pageNumber = 0;
    this.GetProducts();
  }

  OnSortSelected(sort: string){
    this.bookParams.sort = sort;
    this.GetProducts();
  }

  OnPageChanged(event: PageEvent){
    this.bookParams.pageNumber = event.pageIndex;
    this.bookParams.pageSize = event.pageSize;
    this.totalCount = event.length;
    this.GetProducts();
  }

  OnSearch(){
    this.bookParams.search = this.searchTerm.nativeElement.value;
    this.GetProducts();
  }

  OnReset(){
    this.searchTerm.nativeElement.value = '';
    this.bookParams = new BookParams();
    this.GetProducts();
  }

}
