import { Component, Input, OnInit } from "@angular/core";
import { AddToCartService } from "../../services/add-to-cart.service";
import { Carts } from "../../models/cart";
import { DishService } from "../../services/dish.service";
import { Dishes } from "../../models/dishes";

@Component({
  selector: "app-cart",
  templateUrl: "./cart.component.html",
  styleUrls: ["./cart.component.scss"],
})
export class CartComponent implements OnInit {
  @Input() userId: string = "";
  cartd: Carts = new Carts("", 0, '',[], [], []);
  carts: Carts[] = [];
  total: number = 0;
  arrDishes:Dishes[]=[]
  cartdishes:Dishes[]=[]

  constructor(private cartService: AddToCartService, private ds: DishService) {
    this.ds.getDishes().subscribe(data=>{
      this.arrDishes=data
    })
  }

  ngOnInit() {
    if (this.userId) {
      this.getCartData();
    } else {
      console.error("User ID is not provided");
    }
  }

  getCartData() {
    this.cartService.getCart().subscribe(
      (data) => {
        data.forEach((ca) => {
          if (ca.userid == this.userId) {
            this.cartd = ca;
            ca.cartdish.forEach(c=>{
              for(let i=0;i<this.arrDishes.length;++i){
                if(this.arrDishes[i].id==c.d_id){
                    c.dish=this.arrDishes[i]
                    this.cartdishes.push(this.arrDishes[i])
                }
              }
            })
            this.calculateTotal()
            this.cartd.cartdish.forEach(d=>{
              d.dish = undefined
            })
            this.cartService.updateCart(this.cartd.id, this.cartd).subscribe();
          }
        });
      },
      (error) => {
        console.error("Failed to fetch cart data:", error);
      }
    );
  }

  calculateTotal() {
    this.total = 0;
    for (let i = 0; i < this.cartd.cartdish.length; i++) {
      this.total +=this.cartd.cartdish[i].quantity * this.cartdishes[i].price;
      this.cartd.Amount = this.total;
    }
  }

  AddQty(index: number) {
    ++this.cartd.cartdish[index].quantity;
    this.calculateTotal()
    this.cartService.updateCart(this.cartd.id, this.cartd).subscribe();
  }

  SubQty(index: number) {
    if (this.cartd.cartdish[index].quantity > 0) {
      --this.cartd.cartdish[index].quantity;
      this.calculateTotal()
      this.cartService.updateCart(this.cartd.id, this.cartd).subscribe();
    }
  }
}
