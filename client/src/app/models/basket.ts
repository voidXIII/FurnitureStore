import { v4 as uuidv4} from 'uuid';

export interface IBasket {
    id: string
    items: IBasketItem[]
    clientSecret?: string
    paymentIntentId?: string
    deliveryTypeId?: number
    deliveryPrice?: number
  }
  
  export interface IBasketItem {
    id: number
    productName: string
    price: number
    quantity: number
    imageUrl: string
    topology: string
  }

  export class Basket implements IBasket{
      id = uuidv4();
      items: IBasketItem[] = [];
  }

  export interface IBasketTotals {
    order: number;
    delivery: number;
    total: number
  }