import { Component } from '@angular/core';
import { Address } from '../../../models/address';
import { Users } from '../../../models/Users';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { UserService } from '../../../services/user.service';

export function DOBValidator (control: AbstractControl): ValidationErrors | null { 
  const eighteenYearsInMillis = 5.67648e11;
  let birthDate = new Date(control.value);
  //console.log(birthDate);
  if (new Date().getTime() - new Date(birthDate).getTime() <= eighteenYearsInMillis)
  return { invalidDOB: true };
  return null;
  }
  
@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrl: './update-user.component.scss'
})
export class UpdateUserComponent {
  arrUsers:Users[]=[]
  arrAdd:Address[]=[]
  tempUser:Users = new Users('','','','','','',new Address('','','','','','',''),new Date)
  user:Users = new Users('','','','','','',new Address('','','','','','',''), new Date)
  tempAdd:Address = new Address('','','','','','','')
  updateUserForm:FormGroup;
  idup:string=''
  addressid:string=""

  constructor(fb:FormBuilder,private us:UserService){
    this.updateUserForm = fb.group({
      'id':[0], 
      'firstName':['',Validators.required],
      'lastName':['',Validators.required],
      'DOB':['',Validators.compose([Validators.required,DOBValidator])],
     // 'role':[''],
      'email':['',Validators.required],
      'password':['',Validators.required],
      'houseno':['',Validators.required],
      'street':['',Validators.required],
      'area':['',Validators.required],
      'city':['',Validators.required],
      'pincode':['',Validators.required],
      'country':['',Validators.required]
    });
    us.getUsers().subscribe(data=>{
      this.arrUsers = data
    })
  }
  OnSubmit(updateUserFormValue: any):void
  {
    console.log('Submited: ',updateUserFormValue)
    console.log(updateUserFormValue.firstName)
    this.tempAdd = new Address(this.addressid,updateUserFormValue.houseno,updateUserFormValue.street,updateUserFormValue.area,updateUserFormValue.city,updateUserFormValue.pincode,updateUserFormValue.country)
    this.tempUser = new Users(this.idup,updateUserFormValue.firstName,updateUserFormValue.lastName,'user',updateUserFormValue.email,updateUserFormValue.password,this.tempAdd,updateUserFormValue.DOB)
    this.us.UpdateUser(this.idup,this.tempUser).subscribe(data=>
      console.log("Updated",data)
    )
  }

  onChangeType(evt: any) {
    const selectedUserId = parseInt(evt.target.value.split(':')[1].trim(), 10);
    this.idup = selectedUserId.toString();
  
    this.us.getUserById(this.idup).subscribe(data => {
      this.user = data;
      console.log(this.user.DOB)

      const timestampDate = new Date(this.user.DOB);
      const convertedDate = timestampDate.toISOString().split("T")[0];
      //console.log(this.user.DOB)

      //this.id = this.user.Address.id
      if (this.user) {
        this.addressid = this.user.Address.id
        this.updateUserForm.patchValue({
          id: this.user.id,
          firstName: this.user.firstName,
          lastName: this.user.lastName,
          DOB: convertedDate,
          //role: this.user.role,
          email: this.user.email,
          password: this.user.password,
          houseno: this.user.Address.houseno,
          street: this.user.Address.street,
          area: this.user.Address.area,
          city: this.user.Address.city,
          pincode: this.user.Address.pincode,
          country: this.user.Address.country
          

        });
      }
    });
  }
  
  
  
  
 }
