export interface IOrderToCreate {
    basketId: string
    deliveryTypeId: number
    address: IAddress
}

export interface IAddress {
    firstName: string
    lastName: string
    country: string
    city: string
    street: string
    zipCode: string
}
export interface IOrder {
    id: number
    email: string
    dateOfOrder: string
    address: IAddress
    deliveryType: string
    deliveryPrice: number
    orderedProducts: IOrderedProduct[]
    sum: number
    total: number
    status: string
}

export interface IOrderedProduct {
    productId: number
    productName: string
    imageUrl: string
    price: number
    quantity: number
}