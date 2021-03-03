import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

@Component({
  templateUrl: './feedback.component.html',
  styleUrls: ['../components.css']
 })
export class FeedBackComponent {

  emailForm = new FormControl('', [Validators.required, Validators.email]);
  textForm =  new FormControl('', [Validators.required]);
  email: string;
  text: string;

  getErrorMessage() {
    if (this.emailForm.hasError('required') || this.textForm.hasError('required')) {
      return 'You must enter a value';
    }
    return this.emailForm.hasError('email') ? 'Not a valid email' : '';
  }

  send() {
    if (!this.emailForm.invalid && !this.textForm.invalid) {
      console.log(this.email + ' ' + this.text);
    }
  }

}
