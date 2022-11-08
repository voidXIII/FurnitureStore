import { Pipe, PipeTransform } from "@angular/core"

export interface IProduct {
  id: number
  model: string
  productName: string
  imageUrl: string
  price: number
  topology: string
  function: string
  dimensions: string
  description: string
}

@Pipe({
  name: "perDay"
})

export class PerDayPipe implements PipeTransform {
  transform(value: any) {
    return value + " / night"
  }
}

