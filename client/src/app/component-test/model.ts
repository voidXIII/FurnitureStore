import { Pipe, PipeTransform } from "@angular/core";

export interface Employee {
    empCode: number;
    empName: string;
}


@Pipe({
    name:"myPipe"
})
export class MyPipe implements PipeTransform{
    transform(val: any) {
        return val + " Developer";
    }
}