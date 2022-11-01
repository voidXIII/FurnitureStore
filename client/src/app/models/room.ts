import { Pipe, PipeTransform } from "@angular/core"

export interface IRoom {
  id: number
  roomNumber: number
  roomName: string
  roomMainImageUrl: string
  roomPrice: number
  bookingStatus: string
  roomType: string
  roomCapacity: number
  roomDescription: string
}

@Pipe({
  name: "perDay"
})

export class PerDayPipe implements PipeTransform {
  transform(value: any) {
    return value + " / night"
  }
}

