import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from './data.service';
import { Product } from './product';

@Component({
  providers: [DataService],
  templateUrl: './product-detail.component.html'
})
export class ProductDetailComponent implements OnInit {

    id: number;
    product: Product;
    loaded: boolean = false;

    constructor(private dataService: DataService, activeRoute: ActivatedRoute) {
      this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

    ngOnInit() {
      if(this.id){
        this.dataService.getProduct(this.id).subscribe((data: Product) => {
          this.product = data;
          this.loaded = true;
        });
      }
    }

}
