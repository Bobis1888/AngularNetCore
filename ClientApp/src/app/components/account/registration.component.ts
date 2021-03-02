import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../../models/User';
import { AccountService } from '../../services/account.service';

@Component({
  templateUrl: './registration.component.html',
  providers: [AccountService],
  styleUrls: ['../components.css']
 })
export class RegistrationComponent {

  constructor(private accountService: AccountService,private router:Router) {
    if (accountService.getCurrentUser().trusted) {
      this.router.navigate(['info'])
    }
  }

  user = new User();
  hide = false;
  bad = false;
  email = new FormControl('', [Validators.required, Validators.email]);
  // TODO add pass validate
  pass : Array<FormControl> = [new FormControl('', [Validators.required]),new FormControl('', [Validators.required])];

  getErrorMessage() {
    if (this.email.hasError('required') || this.pass[0].hasError('required') || this.pass[1].hasError('required')) {
      return 'You must enter a value';
    }
    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  reg() {
    if (this.email.valid && this.pass[0].valid && this.pass[1].valid) {
      this.accountService.reg(this.user).then((user:User) => {
        if (!user.trusted) {
          this.email.setValue('');
          this.pass[0].setValue('');
          this.pass[1].setValue('');
        }else {
          this.router.navigate(['info']);
        }
      });
    }
  }
}
