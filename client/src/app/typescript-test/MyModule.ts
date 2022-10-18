export interface IEmployee {

    name: string;
    getSalary:() => number;
  }
  
export class Employee implements IEmployee { 
      protected empCode: number;
      name: string;
  
      constructor(name: string) { 
          this.empCode = this.getRandomCode();
          this.name = name;
      }
  
      getSalary():number { 
          return 9999;
      }
  
      private getRandomCode(): number {
        return Math.floor(Math.random() * 10);
      }
  }