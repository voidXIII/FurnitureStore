import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import { ChildComponent } from '../child/child.component';
import { Employee } from '../model';

@Component({
  selector: 'app-parent',
  templateUrl: './parent.component.html',
  styleUrls: ['./parent.component.scss']
})
export class ParentComponent implements AfterViewInit {
  @Input() employees: Employee[]
  
  @ViewChild(ChildComponent)
  child: ChildComponent;

  constructor() { }

  ngAfterViewInit(): void {
    this.child.message = "This is a message from parent";

  }

  TestViewChild(){
    this.child.Intro();
  }

  addNewName(name: string){
    this.employees.push({
      empName: name,
      empCode: this.employees.length + 1
    })
  }

}
