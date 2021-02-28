import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { User } from '../../models/User';
import { Router } from '@angular/router';
import { AccountService } from '../../services/account.service';
import {ASPResponse} from "../../models/ASPResponse";

@Component({
  templateUrl: './login.component.html',
  providers: [AccountService],
  styleUrls: ['../components.css']
 })
export class LoginComponent {

  constructor(private accountService: AccountService,private router: Router) {

  }

  user = new User();
  hide = false;
  bad = false;
  email = new FormControl('', [Validators.required, Validators.email]);
  // TODO add pass validate
  pass = new FormControl('', [Validators.required]);

  getErrorMessage() {
    if (this.email.hasError('required') || this.pass.hasError('required')) {
      return 'You must enter a value';
    }
    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  login() {
    if (this.email.valid && this.pass.valid) {
      this.accountService.login(this.user).then((user:User) => {
        if (!user.trusted) {
          this.email.setValue('');
          this.pass.setValue('');
        }else {
          this.router.navigate(['info']);
        }
      });
    }
  }
}
