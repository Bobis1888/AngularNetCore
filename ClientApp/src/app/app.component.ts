import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Product } from './product';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styles: [`
      div.header , div.container {
        padding: 15px;
        display: flex;
        justify-content: center;
      }
      div.container {
        font-size:16px;
        font-family:Verdana;
        background-color:#29b6f6;
        border: solid 5px;
        border-radius: 5px;
      }
    `]
})
export class AppComponent {}
