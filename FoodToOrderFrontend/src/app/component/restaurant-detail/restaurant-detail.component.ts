import { Component } from '@angular/core';
import { Resturants } from '../../models/restaurant';
import { RestaurantService } from '../../services/restaurantService';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Carts } from '../../models/cart';
import { Dishes } from '../../models/dishes';
import { AddToCartService } from '../../services/add-to-cart.service';
import { DishService } from '../../services/dish.service';
import { CartDish } from '../../models/cartdish';

@Component({
  selector: 'app-restaurant-detail',
  templateUrl: './restaurant-detail.component.html',
  styleUrls: ['./restaurant-detail.component.scss'],
})
export class RestaurantDetailComponent {
  r: Resturants = new Resturants('', '', '', [], [], true,'');
  
  rId: string = "";
  id: string = "";
  flag: boolean = false;
  tempcart: CartDish = new CartDish('','',0)
  cart: Carts = new Carts('', 0,'', [], [],[]);
  cartold: Carts = new Carts('', 0,'', [], [],[]);
  buttonVisible: boolean = false;
  arrDishes:Dishes[]=[]
  cid:string=""
  constructor(
    private activatedRoute: ActivatedRoute,
    private rs: RestaurantService,
    private cs: AddToCartService,
    private router: Router,
    private ds:DishService
  ) {
this.ds.getDishes().subscribe(data=>{
  this.arrDishes=data
})




    this.activatedRoute.params.subscribe((params: Params) => {
      //console.log('Route Params:', params);
      //console.log(this.r.id);
      var rid = params['id'];
      this.rId = rid;
      //console.log('rid:', rid);
      if (rid) {
        this.rs.getRestById(rid).subscribe((data) => {
          this.r = data;
        });
      } else {
        this.router.navigate(['/**']);
      }
      const showButton = params['showButton'];
      if (showButton === 'true') {
        this.buttonVisible = true;
      } else {
        this.buttonVisible = false;
      }
    });
  }

  addToCart(did: string) {
    this.id = (localStorage.getItem('userid')!);
    this.cs.getCart().subscribe(data=>{
       data.forEach(cart=>{
          if(cart.userid==this.id){
            this.cid=cart.id
            //console.log("idid:",this.cid)
          }
       })
    

    this.flag = false;
    //this.id = (localStorage.getItem('userid')!);
    //console.log(this.id);

    if (parseInt(this.id) > 0) {
      this.cs.getCartById(this.cid).subscribe((data) => {
        this.cart = data;
        data.cartdish.forEach(c=>{
          for(let i=0;i<this.arrDishes.length;++i){
            if(this.arrDishes[i].id==c.d_id){
                //c.dish=this.arrDishes[i]
            }
          }
        })
       
        for(let i=0;i<this.cart.cartdish.length;i++){
          if(this.cart.cartdish[i].d_id==did){
            this.flag=true
          }
          this.ds.getDishById(this.cart.cartdish[i].d_id).subscribe(data=>{
           //this.cart.cartdish[i].dish=data
          })
     }
        if(!this.flag){
          
            for (let i = 0; i < this.r.dishlist.length; i++) {
              //console.log(this.rdish.dishlist[i])
              if (this.r.dishlist[i].id == did) {
                console.log(this.r.dishlist[i])
                this.tempcart.c_id = this.cart.id
                this.tempcart.d_id = did
                //this.tempcart.dish = this.r.dishlist[i]
                this.tempcart.quantity = 1
                //this.tempcart.cart.id = this.cart.id
                //this.tempcart.cart.userid = this.cart.userid
                this.cart.cartdish.push(this.tempcart)
                this.cart.Amount += this.r.dishlist[i].price;
              }
            }
            console.log(this.cart)
          
        }
        else{
          for (let i = 0; i < this.cart.cartdish.length; i++) {
            if (this.cart.cartdish[i].d_id == did) {
              this.cart.cartdish[i].quantity++;
            }
          }
        }
        this.cart.cartdish.forEach(d=>{
          d.dish = undefined
        })
        this.cs.updateCart(this.cid, this.cart).subscribe();
       
      });
    }
   else {
      alert('Please Sign In!');
    }
    })
  }
}
