import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { orders } from '../../../models/order';
import { Users } from '../../../models/Users';
import { OrderService } from '../../../services/orders.service';
import { UserService } from '../../../services/user.service';
import { OrderDish } from '../../../models/orderdish';
import { Dishes } from '../../../models/dishes';
import { DishService } from '../../../services/dish.service';


@Component({
  selector: 'app-update-order',
  templateUrl: './update-order.component.html',
  styleUrl: './update-order.component.scss'
})
export class UpdateOrderComponent {
  order:orders=new orders('','','',0,[],[],[])
  order1:orders[]=[]
  oid:number=0
  // public OrderForm:FormGroup
  updateOrderFirstFormGroup:FormGroup
  updateSecondFormGroup:FormGroup
  dishListForm:FormGroup
  count: number=0;
  arrUsers:Users[]=[]
  idUpdated:string=''
  arrOrders:orders[]=[]
  cnt:number=0
  orderDate=""
  orderAmount=0
  orderdish:OrderDish[]=[]
  orderdishfinal:OrderDish[]=[]
  dishes:Dishes[]=[]
  arrDishes:Dishes[]=[]
  temparrDishes:Dishes[]=[]
  arrDishesRest:Dishes[]=[]
  restaurantid:string=""
  
constructor(private _formBuilder: FormBuilder, private orderService:OrderService, private userService:UserService, private dishService:DishService) {
  

  this.userService.getUsers().subscribe(data=>{this.arrUsers=data});
  console.log(this.arrUsers)

  this.dishService.getDishes().subscribe(data=>{
    this.arrDishes=data
  })

  this.updateOrderFirstFormGroup = this._formBuilder.group({
    'userId': ['', Validators.required],
    'id':['', Validators.required],
  });

  this.updateSecondFormGroup = this._formBuilder.group({
  });

  this.dishListForm = this._formBuilder.group({
    dishes: this._formBuilder.array([]) // Initialize addresses as a FormArray
  });

}

get dishControls() {
  return (this.dishListForm.get('dishes') as FormArray).controls;
}

  

  viewFirstStepData(formdata:FormGroup){

    this.oid=formdata.value.oid;
    
    this.orderService.getOrder().subscribe(data=>{
      this.order1=data
      console.log(this.order1)}
    );

    console.log(this.oid);
    
}

updateSecondStepData(formdata:FormGroup){
  console.log(formdata)
  }

  public removeOrClearOrder(i: number) {
  }
  

  onChangeUserId(evt:any){
    console.log(evt.target.value)
    var idObtained = evt.target.value
    this.idUpdated = (idObtained.split(':')[1].trim())
    console.log("this.idUpdated",this.idUpdated)
    
    this.orderService.getOrder().subscribe(data=>{
      data.forEach(order=>{
        if(order.userId==this.idUpdated){
            this.arrOrders.push(order)
        }
      })
    })
      
  }
  onChangeOrderId(evt:any){
    var idObtained = evt.target.value
    console.log(evt.target.value)
    this.idUpdated = (idObtained.split(':')[1].trim())
    console.log("this.idUpdated",this.idUpdated)

    this.orderService.getOrderByOrderId(this.idUpdated).subscribe(data=>{
      console.log(data)

      this.orderDate=data.orderDate
      this.orderAmount=data.orderAmount
      
      this.order=data
      this.orderdish=data.orderdish

      const dishesFormArray = this.dishListForm.get('dishes') as FormArray;

      dishesFormArray.clear(); this.cnt=0
      this.order.orderdish.forEach(dish => {
        this.restaurantid = dish.dish.r_id
        const dishFormGroup = this._formBuilder.group({
          dName: [dish.dish.dName, Validators.required],
          price: [dish.dish.price, Validators.required],
          quantity : [dish.quantity, Validators.required],
        });
        dishesFormArray.push(dishFormGroup);
      });

      this.dishService.getDishes().subscribe(data=>{
        data.forEach(dish => {
          if(dish.r_id==this.restaurantid){
            this.arrDishesRest.push(dish)
          }
        });
      })
    }
  
    )
  }

  onChangeName(evt:any){

  }

  removeOrClearDish(index: number) {
    (this.dishListForm.get('dishes') as FormArray).removeAt(index);
    console.log(this.dishListForm.get('dishes'))

  }

  UpdateOrderFormGroup() {
    const dishesFormArray = this._formBuilder.group({
      dName: ['',Validators.required],
      price: ['',Validators.required],
      quantity:['',Validators.required]
    });
    (this.dishListForm.get('dishes') as FormArray).push(dishesFormArray);
    this.orderdish.push(new OrderDish("","",new Dishes("","",0,"","",true),0))

  }
  

  onSubmit():void{
    const id = this.updateOrderFirstFormGroup.get('id')?.value;
    
    const userId = this.updateOrderFirstFormGroup.get('userId')?.value;
    console.log("NEW DLF",this.dishListForm.get('dishes'))

    const dishData = this.dishListForm.value.dishes.map((dish: any) => ({
      id:"0",
      dName: dish.dName,
      price:parseInt(dish.price),
      isAvailable:true,
      img_path:"img_path",
      r_id:"0"
    }));

    
      console.log("arrdishes",this.arrDishes)
      for(let i=0;i<dishData.length;i++){
        for(let j=0;j<this.arrDishes.length;j++){
          
          if(this.arrDishes[j].dName.trim()==dishData[i].dName.trim()){
            dishData[i].id = this.arrDishes[j].id
            this.orderdish[i].d_id = this.arrDishes[j].id
            dishData[i].r_id = this.arrDishes[j].r_id

            this.orderdish[i].dish.dName = this.arrDishes[i].dName
            this.orderdish[i].dish.id = this.arrDishes[i].r_id
            this.orderdish[i].dish.price = this.arrDishes[i].price
            this.orderdish[i].dish.img_path = this.arrDishes[i].img_path
            this.orderdish[i].dish.r_id = this.arrDishes[i].r_id
            this.orderdish[i].dish.isAvailable = this.arrDishes[i].isAvailable
            
          }
      }
    }
      
    

    console.log("DishData",dishData)

    const qtyData: number[] = this.dishListForm.value.dishes.map((dish: any) => parseInt(dish.quantity));
    this.orderAmount=0;
    this.orderAmount = dishData.reduce((total: number, dish: { price: number; }, index: number) => {
      const totalPrice = dish.price * qtyData[index];
      return total + totalPrice;
  }, 0);

  for(let i=0;i<this.dishListForm.value.dishes.length;i++){
    this.orderdish[i].o_id = id
  }
  for(let i=0;i<this.dishListForm.value.dishes.length;i++){
    this.orderdish[i].quantity = qtyData[i]
    this.orderdishfinal.push(this.orderdish[i])
    
  }
  console.log("oooooo",this.orderdish)
    
    const updatedOrderData = {
      id: id,
      orderDate:this.orderDate,
      orderAmount:this.orderAmount,
      userId:userId,
     // arrDishes: dishData,
      orderdish: this.orderdishfinal,
      quantity:qtyData
    };

    console.log(updatedOrderData)
    this.orderService.updateOrder(id, updatedOrderData).subscribe(

      (updatedOrder) => {
        console.log('Restaurant updated successfully:', updatedOrder);
        console.log(updatedOrder.orderAmount)
      },
      (error) => {
        console.error('Failed to update restaurant:', error);
      }
    );
  }

}
