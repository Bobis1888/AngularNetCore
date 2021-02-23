import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data.service';
import { Item } from '../models/Item';

@Component({
  templateUrl: './item-list.component.html',
  providers: [DataService],
  styleUrls: ['./components.css'],
 })
export class ItemListComponent implements OnInit {

  items: Item [];
  progress = true;
  nameSource = 'habr';
  flow = 'all';
  swipeCoord: [number, number];
  swipeTime: number;
  selectedTab: number;

  constructor(private dataService: DataService) {}

  ngOnInit() {
    this.load();
  }

  load() {
    this.progress = true;
    this.items = null;
    this.dataService.getItems(this.nameSource, this.flow).subscribe((data: Item[]) => {
      this.items = data;
      this.progress = false;
    });
  }

  swipe(e: TouchEvent, when: string): void {
    const coord: [number, number] = [e.changedTouches[0].clientX, e.changedTouches[0].clientY];
    const time = new Date().getTime();
    if (when === 'start') {
      this.swipeCoord = coord;
      this.swipeTime = time;
    } else if (when === 'end') {
      const direction = [coord[0] - this.swipeCoord[0], coord[1] - this.swipeCoord[1]];
      const duration = time - this.swipeTime;
      if (duration < 1000 && Math.abs(direction[0]) > 30 && Math.abs(direction[0]) > Math.abs(direction[1] * 3)) {
        const swipe = direction[0] < 0 ? 'next' : 'previous';
        if (swipe === 'next') {
          const isFirst = this.selectedTab === 0;
          if (this.selectedTab < this.items.length - 1) {
            this.selectedTab = isFirst ? 1 : this.selectedTab + 1;
          }
        } else if (swipe === 'previous') {
          const isLast = this.selectedTab === this.items.length - 1;
          if (this.selectedTab >= 1) {
            this.selectedTab = this.selectedTab - 1;
          }
        }
      }
    }
  }

}
