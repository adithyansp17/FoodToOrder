import { Dishes } from "./dishes"
import { OrderDish } from "./orderdish"

export class orders{
    id: string
    userId: string
    orderDate:string
    orderAmount: number
    arrDishes:Dishes[]
    quantity:number[]
    orderdish:OrderDish[]
    constructor(id:string,rid:string,date:string,amt:number,dlist:Dishes[],qty:number[],orderdish:OrderDish[]){
        this.id=id
        this.userId=rid
        this.orderDate = date
        this.orderAmount =amt
        this.arrDishes = dlist
        this.quantity = qty
        this.orderdish=orderdish
    }
}