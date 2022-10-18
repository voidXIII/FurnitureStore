import { Component, OnInit } from '@angular/core';
import { Employee } from './MyModule'


@Component({
  selector: 'app-typescript-test',
  templateUrl: './typescript-test.component.html',
  styleUrls: ['./typescript-test.component.scss']
})
export class TypescriptTestComponent {
  
  array: Employee[] = [new Employee("John"), new Director("Jeka"), new Manager("Andrew"), new Developer("Fiodor")];
  displayString: string = '';
  getRandomType() {
    let first: any;
    let second: any;
    switch (Math.floor(Math.random() * 4)) {
      case 0:
        first = 5;
        second = true;
      break;
      case 1:
        first = "5";
        second = true;
      break;
      case 2:
        first = { Age: 21};
        second = undefined;
      break;
      case 3:
        first = null;
        second = [1, 2, 3];
      break;
      default:
        first = 0;
        second = 0;
        break;
    }
    this.displayString = displayDataType(first, second);
  }

  
}

function displayDataType<T, U>(first:T, second:U) {    
  return `First Field: [${typeof first} : ${first}] <---> Second Field: [${typeof second} : ${second}]`;
}  


class Manager extends Employee{
  override getSalary(): number {
    return 40000;
  }
}

class Director extends Employee {
  override getSalary(): number{
    return 50000;
  }
}

class Developer extends Employee {
  override getSalary(): number {
    return 10000;
  }
}

