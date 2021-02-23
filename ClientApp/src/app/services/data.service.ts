import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';

@Injectable()
export class DataService {

    private url = '/api/items';

    constructor(private http: HttpClient) {
    }

    getItems(nameSource: string, flow: string) {
        return this.http.get(this.url + '/' + nameSource + '/' + flow);
    }

    getItem(nameSource: string, flow: string, postId: string) {
        return this.http.get(this.url + '/' + nameSource + '/' + flow + '/' + postId);
    }
}
