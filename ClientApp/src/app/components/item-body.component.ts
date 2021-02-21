import { Component, OnInit } from '@angular/core';
import { DataService } from './../data.service';
import { Item } from '../models/Item';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  templateUrl: './item-body.component.html',
  providers: [DataService],
  styleUrls: ['./item-list.css']
 })
export class ItemBodyComponent implements OnInit {

  item: Item;
  postID: string;
  nameSource: string;
  flow: string;
  progress = true;

  constructor(private dataService: DataService, activeRoute: ActivatedRoute ) {
    this.postID = activeRoute.snapshot.params['postId'];
    this.nameSource = activeRoute.snapshot.params['nameSource'];
    this.flow = activeRoute.snapshot.params['flow'];
  }

  ngOnInit() {
    if (this.postID) {
      this.load();
    }
  }

  load() {
    this.progress = true;
    this.item = null;
    this.dataService.getItem(this.nameSource, this.flow, this.postID).subscribe((data: Item) => {
      this.item = data;
      this.progress = false;
    });
  }

}
