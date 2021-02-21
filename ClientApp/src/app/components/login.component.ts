import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { DataService } from './../data.service';

@Component({
  templateUrl: './login.component.html',
  providers: [DataService],
  styleUrls: ['./item-list.css']
 })
export class LoginComponent implements OnInit {

  progress = true;
  hide = false;
  bad = false;
  email = new FormControl('', [Validators.required, Validators.email]);
  pass = new FormControl('', [Validators.required]);

  getErrorMessage() {
    if (this.email.hasError('required') || this.pass.hasError('required')) {
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  ngOnInit() {
    this.load();
  }

  load() {}
}
