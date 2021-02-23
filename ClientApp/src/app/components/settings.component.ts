import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data.service';

export interface ChipColor {
  name: string;
  color: string;
}

@Component({
  templateUrl: './settings.component.html',
  providers: [DataService],
  styleUrls: ['./components.css']
 })
export class SettingsComponent implements OnInit {

  availableColors: ChipColor[] = [
    {name: 'Dev', color: 'primary'},
    {name: 'Admin', color: 'accent'},
    {name: 'Design', color: 'warn'},
    {name: 'Managment', color: 'basic'},
  ];

  ngOnInit() {
    this.load();
  }

  load() {}
}
