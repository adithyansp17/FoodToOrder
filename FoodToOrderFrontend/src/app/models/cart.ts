import { CartDish } from "./cartdish"
import { Dishes } from "./dishes"

export class Carts{
    id: string
    Amount: number
    arrDishes: Dishes[]
    quantity: number[]
    userid:string=""
    cartdish:CartDish[]
    
    
    constructor(id:string,p:number,uid:string,disharr:Dishes[],qty:number[],cartdish :CartDish[]){
        this.id=id
        this.Amount = p
        this.userid=uid
        this.arrDishes = disharr
        this.quantity =qty
        this.cartdish=cartdish
    }
}