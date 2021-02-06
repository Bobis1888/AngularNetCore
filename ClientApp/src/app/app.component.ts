import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Product } from './product';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
})
export class AppComponent {

    // product: Product = new Product();   // изменяемый товар
    // products: Product[];                // массив товаров
    // tableMode: boolean = true;          // табличный режим

    // constructor(private dataService: DataService) { }

    // ngOnInit() {
    //     this.loadProducts();    // загрузка данных при старте компонента
    // }
    // // получаем данные через сервис
    // loadProducts() {
    //     this.dataService.getProducts()
    //         .subscribe((data: Product[]) => this.products = data);
    // }
    // // сохранение данных
    // save() {
    //     if (this.product.id == null) {
    //         this.dataService.createProduct(this.product)
    //             .subscribe((data: HttpResponse<Product>) => {
    //               this.products.push(data.body);
    //             });
    //     } else {
    //         this.dataService.updateProduct(this.product)
    //             .subscribe(data => {
    //               this.loadProducts();
    //             });
    //     }
    //     this.cancel();
    // }
    // editProduct(p: Product) {
    //     this.product = p;
    // }
    // cancel() {
    //     this.product = new Product();
    //     this.tableMode = true;
    // }
    // delete(p: Product) {
    //     this.dataService.deleteProduct(p.id)
    //         .subscribe(data => this.loadProducts());
    // }
    // add() {
    //     this.cancel();
    //     this.tableMode = false;
    // }
}
