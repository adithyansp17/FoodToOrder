  import { Component } from '@angular/core';
  import { Router } from '@angular/router';
  import { UserService } from '../services/user.service';
  import { Users } from '../models/Users';
  import { Carts } from '../models/cart';
  import { AddToCartService } from '../services/add-to-cart.service';
  import { orders } from '../models/order';
  import { OrderService } from '../services/orders.service';
  import { delay } from 'rxjs';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { OrderDish } from '../models/orderdish';
import { Dishes } from '../models/dishes';
import { DishService } from '../services/dish.service';




  @Component({
    selector: 'app-banner',
    templateUrl: './banner.component.html',
    styleUrls: ['./banner.component.scss'],
  })

  export class BannerComponent {
    username: string = localStorage.getItem('username')!;
    user: UserService;
    arrUser: Users[] = [];
    cartd: Carts = new Carts("", 0, '',[], [],[]);
    total: number = 0;
    id: string = "";
    max: number = 0;
    defaultValue: string = "user";
    tempo: orders = new orders('','','',0,[],[],[]);
    cart: Carts = new Carts("", 0, '',[], [],[]);
    x:string= ""
    newOrderdish: OrderDish[]=[]
    tempOrderDish: OrderDish = new OrderDish('','',new Dishes('','',0,'','',true),0)
    arrDishes:Dishes[]=[]
    isLoggedIn: boolean = JSON.parse(localStorage.getItem('logg')!) 
    useradmin: boolean = JSON.parse(localStorage.getItem('admn')!)
    cartEmpty: boolean = false

    signInForm: FormGroup;

    constructor(
      private router: Router,
      private users: UserService,
      private cs: AddToCartService,
      private ors: OrderService,
      private ds : DishService
    ) {


      this.signInForm = new FormGroup({
        email: new FormControl('', [Validators.required]),
        password: new FormControl('', [Validators.required])
      });

      this.ds.getDishes().subscribe(data=>{
        this.arrDishes=data
      })
      
      this.user = users;
      const userId = parseInt(localStorage.getItem('userid') || '', 10);
      if (!isNaN(userId)) {
        this.id = userId.toString();
      }
      cs.getCart().subscribe((data) => {
        data.forEach(ca=>{
          if(ca.userid==this.id){
              this.cart = ca
              if(ca.cartdish.length>0){
                this.cartEmpty = true
              }
          }
        })
      });
    
      console.log('defaultValue:', this.defaultValue); // Check the value here
    }
    // ngOnInit(): void {
    //   this.signInForm = new FormGroup({
    //     email: new FormControl('', [Validators.required, Validators.email]),
    //     password: new FormControl('', [Validators.required, Validators.minLength(8)])
    //   });
    // }

    Validate(email: HTMLInputElement, pwd: HTMLInputElement) {
      var loginFlag = false
      this.users.getUsers().subscribe((data) => {
        this.arrUser = data;

        for (let i = 0; i < this.arrUser.length; ++i) {
          if (
            email.value == this.arrUser[i].email &&
            pwd.value == this.arrUser[i].password
          ) {
            
          loginFlag = true
            localStorage.setItem('logg','true')
            
            this.isLoggedIn =JSON.parse(localStorage.getItem('logg')!.toLowerCase())
            localStorage.setItem('username',this.arrUser[i].firstName)
            this.username = this.arrUser[i].firstName;
            if (this.arrUser[i].role == 'admin') {
              localStorage.setItem('role', 'admin');
              localStorage.setItem('userid', this.arrUser[i].id.toString());
              this.router.navigate(['/admin']);
              localStorage.setItem('admn','true')
              this.useradmin = JSON.parse(localStorage.getItem('admn')!)
            } else {
              localStorage.setItem('role', 'user');
              localStorage.setItem('userid', this.arrUser[i].id.toString());
              this.router.navigate(['/home']);
              // this.cart.id = this.arrUser[i].id;
              // this.cs.AddCart(this.cart).subscribe();
              localStorage.setItem('admn','false')
              this.useradmin = JSON.parse(localStorage.getItem('admn')!)
            }
          } else {
            //alert("Invalid Login credentials..");
            this.router.navigate(['/home']);
          }
        }
        if(!loginFlag){
          alert("Invalid Login credentials..");
        }
      });
    }

    logout() {
      localStorage.setItem('logg','false')
      this.isLoggedIn = JSON.parse(localStorage.getItem('logg')!.toLowerCase())
      console.log(this.isLoggedIn)
      this.router.navigate(['/home']);
      this.cartd = new Carts('', 0, '',[], [],[]);
      this.total = 0;
      localStorage.setItem('userid', '0');
      localStorage.setItem('admn','false')
      this.useradmin = JSON.parse(localStorage.getItem('admn')!)
      localStorage.setItem('role','')
      localStorage.setItem('username','')
    }

    navigateToAddUser() {
      const defaultValue = 'user';
      this.router.navigate(['/add-user'], { queryParams: { defaultValue } });
    }

    checkout() {
      this.ors.getOrder().subscribe(data=>{
        
          const largestId = Math.max(...data.map((item) => parseInt(item.id)));
        console.log("here",largestId)
        this.x = (largestId + 1).toString()
       
      })
  
      this.cs.getCart().subscribe(data=>{
        data.forEach(c=>{
          if(c.userid==this.id){
            this.cartd = c
          }
        })
        
        for(let i=0;i<this.cartd.cartdish.length;++i){
           var tempOrderDish = new OrderDish('','',new Dishes('','',0,'','',true),0) 
            tempOrderDish.o_id = '0'
            tempOrderDish.d_id = this.cartd.cartdish[i].d_id
            tempOrderDish.quantity = this.cartd.cartdish[i].quantity
            this.newOrderdish.push(tempOrderDish)
            
        }
        
        this.tempo = new orders(
          '0',
          this.id,
          (new Date()).toISOString(),
          this.cartd.Amount,
          [],
          [],
          this.newOrderdish
        );

        this.tempo.orderdish.forEach(od => {
          od.dish=null as any
        });
        this.ors.addOrder(this.tempo).subscribe();
  
         this.cs.DeleteCart(this.cartd.id).subscribe();
         
         var newcart = new Carts('0',0,this.cartd.userid,[],[],[])
         this.cs.AddCart(newcart).subscribe();
  
        alert("Order confirmed with Rs." + this.cartd.Amount)
      });
    }
  }
