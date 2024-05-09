import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnChanges, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Users } from '../../models/Users';
import { Address } from '../../models/address';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrl: './contact-us.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})


export class ContactUsComponent implements OnInit {
  fullName: string = '';
  email: string = '';
  mobile: string = '';
  msg: string = '';
  errorMessage: string = '';

  constructor() {}

  ngOnInit() {}

  onSubmit() {
    this.errorMessage = ''; 

    if (this.fullName.trim() === '') {
      this.errorMessage = 'Please enter your full name.';
      return;
    }

    if (!this.validateEmail(this.email)) {
      this.errorMessage = 'Please enter a valid email address.';
      return;
    }

    // const mobileRegex = /^\d+$/;
    // if (!mobileRegex.test(this.mobile.trim())) {
    //   this.errorMessage = 'Please enter a valid contact number (digits only).';
    //   return;
    // }

    if (this.msg.trim().length < 10) {
      this.errorMessage = 'Please write a message with at least 10 characters.';
      return;
    }

    console.log('Form submitted successfully:', this.fullName, this.email, this.mobile, this.msg);
  }

  validateEmail(email: string) {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email.trim());
  }
}
