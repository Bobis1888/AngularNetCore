import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Item } from './models/Item';

@Injectable()
export class DataService {

    private url = "/api/items";

    constructor(private http: HttpClient) {
    }

    getItems() {
        return this.http.get(this.url);
    }

    getItem(postId: string) {
        return this.http.get(this.url + '/' + postId);
    }

    createItem(item: Item) {
        return this.http.post(this.url, item, {observe: 'response'});
    }
    updateItem(item: Item) {

        return this.http.put(this.url, item);
    }
    deleteItem(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}
