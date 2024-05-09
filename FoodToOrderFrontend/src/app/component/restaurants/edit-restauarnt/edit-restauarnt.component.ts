import { Component } from '@angular/core';
import { Address } from '../../../models/address';
import {
  AbstractControl,
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { RestaurantService } from '../../../services/restaurantService';
import { Resturants } from '../../../models/restaurant';
import { Dishes } from '../../../models/dishes';
import { DishService } from '../../../services/dish.service';

@Component({
  selector: 'app-edit-restauarnt',
  templateUrl: './edit-restauarnt.component.html',
  styleUrl: './edit-restauarnt.component.scss',
})
export class EditRestauarntComponent {
  isLinear = false;
  arrRes: Resturants[] = [];
  firstFormGroup: FormGroup;
  idup: string = '';
  r: Resturants = new Resturants('', '', '', [], [], true,'');
  secondFormGroup: FormGroup;
  addressListForm: FormGroup;
  thirdFormGroup: FormGroup;
  dishListForm: FormGroup;
  tempRes: Resturants = new Resturants('', '', '', [], [], true,'');
  arrAdd: Address[] = [];
  tempAdd: Address = new Address('', '', '', '', '', '', '');
  tempDish: Dishes = new Dishes('', '', 0, '', '', true);
  addId: number = 1;
  dishId: number = 1;
  open:boolean=true
  loc:string=""

  constructor(private fb: FormBuilder, private restService: RestaurantService,private ds:DishService) {
    this.firstFormGroup = this.fb.group({
      id: [null],
      rNameCtrl: [''],
      TypeCtrl:[''],
      rOpen:['']
    });

    this.secondFormGroup = this.fb.group({});

    this.addressListForm = this.fb.group({
      addresses: this.fb.array([]),
    });

    this.thirdFormGroup = this.fb.group({
      dishes: this.fb.array([]),
    });

    this.dishListForm = this.fb.group({
      dishes: this.fb.array([]),
    });

    restService.getRestaurant().subscribe((data) => {
      this.arrRes = data;
    });
  }

  get addressControls() {
    return (this.addressListForm.get('addresses') as FormArray).controls;
  }

  get dishControls() {
    return (this.dishListForm.get('dishes') as FormArray).controls;
  }

  saveThirdStepData(formData: any) {
    console.log('Saved:', formData);
  }

  onSubmit(): void {
    const id = this.firstFormGroup.get('id')?.value;
    const rName = this.firstFormGroup.get('rNameCtrl')?.value;
    if (this.firstFormGroup.get('rOpen')?.value=='yes')
     this.open = true;
  else{
this.open=false
  }
  const Type = this.firstFormGroup.get('TypeCtrl')?.value;

    const addressData = this.addressListForm.value.addresses.map(
      (address: any) => ({
        id: address.id,
        houseno: address.houseno,
        street: address.street,
        area: address.area,
        city: address.city,
        pincode: address.pincode,
        country: address.country,
      })
    );
    
    const dishData = this.dishListForm.value.dishes.map((dish: any) => (
      {
      id: dish.id,
      dName: dish.dName,
      price: dish.price,
      img_path: dish.img_path,
      isAvailable: dish.isAvailable == 'no' ,
    }));
    


    //console.log("dishid :" + this.dishListForm.value.dishes[0].id)

    const updatedRestaurantData = {
      id: id,
      rName: rName,
      rOpen:this.open,
      location:this.loc,
      user_id:"1",
      arrAddress: addressData,
      dishlist: dishData,
      Type:Type
    };
    console.log(updatedRestaurantData)
    this.restService.updateRestaurant(id, updatedRestaurantData).subscribe(
      (updatedRestaurant) => {
        console.log('Restaurant updated successfully:', updatedRestaurant);
      },
      (error) => {
        console.error('Failed to update restaurant:', error);
      }
    );
  }

  onChangeType(evt: any) {
    const selectedRestaurantId = evt.target.value;
    this.idup = (selectedRestaurantId.split(':')[1].trim());
    console.log('This.idup: ', this.idup);

    this.restService.getRestById(this.idup).subscribe((data) => {
      console.log('Restaurant data:', data);
      this.r = data;
      if (this.r) {
        this.firstFormGroup.get('rNameCtrl')?.setValue(this.r.rName);
        this.firstFormGroup.get('TypeCtrl')?.setValue(this.r.Type);
        this.firstFormGroup.get('rOpen')?.setValue(this.r.ROpen?"yes":"no");
        this.loc=this.r.location

        const addressesFormArray = this.addressListForm.get(
          'addresses'
        ) as FormArray;
        addressesFormArray.clear();
        if (this.r.arrAddress) {
          this.r.arrAddress.forEach((address) => {
            const addressFormGroup = this.fb.group({
              id:[address.id],
              houseno: [address.houseno, Validators.required],
              street: [address.street, Validators.required],
              area: [address.area, Validators.required],
              city: [address.city, Validators.required],
              pincode: [address.pincode, Validators.required],
              country: [address.country, Validators.required],
            });
            addressesFormArray.push(addressFormGroup);
          });
        }

        const dishesFormArray = this.dishListForm.get('dishes') as FormArray;
        dishesFormArray.clear();
        if (this.r.dishlist) {
          console.log('has dishes');
          this.r.dishlist.forEach((dish) => {
            const dishFormGroup = this.fb.group({
              id: [dish.id],
              dName: [dish.dName, Validators.required],
              price: [dish.price, Validators.required],
              img_path: [dish.img_path],
              isAvailable: [dish.isAvailable ? 'yes' : 'no'],
            });
            dishesFormArray.push(dishFormGroup);
          });
        }
      }
    });
  }

  addItineraryFormGroup() {
    const addressFormGroup = this.fb.group({
      houseno: [''],
      street: [''],
      area: [''],
      city: [''],
      pincode: [''],
      country: [''],
    });

    (this.addressListForm.get('addresses') as FormArray).push(addressFormGroup);
  }

  removeOrClearItinery(index: number) {
    const ad = this.addressListForm.get('addresses') as FormArray;
    var id = ad.at(index).value["id"] 
    this.ds.deleteAddress(id).subscribe();
    (this.addressListForm.get('addresses') as FormArray).removeAt(index);
  }

  addDishFormGroup() {
    const dishesFormArray = this.fb.group({
      dName: ['', Validators.required],
      price: ['', Validators.required],
      img_path: [''],
      isAvaiable: ['yes'],
    });

    (this.dishListForm.get('dishes') as FormArray).push(dishesFormArray);
  }

  addressControl(index: number): AbstractControl {
    return (this.addressListForm.get('addresses') as FormArray).at(index);
  }

  removeOrClearDish(index: number) {
    const d = this.dishListForm.get('dishes') as FormArray;
    var id = d.at(index).value["id"] 
    this.ds.deleteDish(id).subscribe();
    (this.dishListForm.get('dishes') as FormArray).removeAt(index);
  }

  saveSecondStepData(formData: any) {
    console.log(formData);
  }
}
