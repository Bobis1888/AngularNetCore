import { Component, Output } from '@angular/core';
import { EventEmitter } from 'events';


@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
  })
export class AppComponent {

  reference: any;

  update() {
    this.reference.load();
  }

  onActivate (componentReference) {
    this.reference = componentReference;
 }

}
