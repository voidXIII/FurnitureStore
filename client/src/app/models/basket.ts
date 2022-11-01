import { v4 as uuidv4} from 'uuid';

export interface IBasket {
    id: string
    items: IBasketItem[]
  }
  
  export interface IBasketItem {
    id: number
    roomName: string
    price: number
    quantity: number
    roomPictureUrl: string
    type: string
  }

  export class Basket implements IBasket{
      id = uuidv4();
      items: IBasketItem[] = [];
  }

  export interface IBasketTotals {
    total: number
  }