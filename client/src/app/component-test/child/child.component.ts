import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.scss']
})
export class ChildComponent implements OnInit {
  @Output() addName = new EventEmitter<string>();
  message: string;
  constructor() { }

  ngOnInit(): void {
  }

  AddNewName(name: HTMLInputElement){
    this.addName.emit(name.value);
    name.value = '';
  }

  Intro(){
    this.message = "This is your child component texting";
  }
}
