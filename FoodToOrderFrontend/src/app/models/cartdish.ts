import { Carts } from "./cart"
import { Dishes } from "./dishes"

export class CartDish{
    c_id: string
    d_id: string
    dish?:Dishes = new Dishes('','',0,'','',true)
    quantity: number
    //cart:Carts = new Carts('',0,'',[],[],[])
    
    
    constructor(cid:string,did:string,qty:number){
        this.c_id=cid
        this.d_id=did
        this.quantity =qty
    }
}