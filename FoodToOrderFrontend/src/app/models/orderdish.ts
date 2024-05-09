import { orders } from "./order"
import { Dishes } from "./dishes"

export class OrderDish{
    o_id: string
    d_id: string
    dish:Dishes
    quantity: number
    
    
    constructor(oid:string,did:string,dish:Dishes,qty:number){
        this.o_id=oid
        this.d_id=did
        this.quantity =qty
        this.dish=dish
    }
}