import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import { ASPResponse } from '../models/ASPResponse';
import { User } from '../models/User';
import { Observable, throwError } from 'rxjs';
import { catchError,tap } from 'rxjs/operators';
import {Settings} from "../models/Settings";

@Injectable()
export class AccountService {

    private url = '/api/account';
    static currentUser = new User();

    constructor(private http: HttpClient) {}

    public getCurrentUser() {
      return AccountService.currentUser;
    }

    login(user: User): Promise<User> {
      return this._post(user,'login')
        .then(resp => AccountService.currentUser = resp.user);
    }

    reg(user: User): Promise<User> {
      return this._post(user,'registration')
        .then(resp => AccountService.currentUser = resp.user);
    }

    info(): Promise<Settings> {
      return this._post(AccountService.currentUser,'info')
        .then(resp => AccountService.currentUser.settings = resp.settings)
    }

    private _post(user: User,url: string): Promise<ASPResponse> {
      return this.http
        .post<ASPResponse>(this.url + '/' + url, user)
        .pipe(catchError(this.handleError)).toPromise()
        .then(response => response);
    }

    logout() {
      AccountService.currentUser = new User();
      this.http.get(this.url + '/logout').toPromise();
    }

    private handleError(error: HttpErrorResponse) {
      if (error.error instanceof ErrorEvent) {
        // A client-side or network error occurred. Handle it accordingly.
        console.error('An error occurred:', error.error.message);
      } else {
        // The backend returned an unsuccessful response code.
        // The response body may contain clues as to what went wrong.
        console.error(
          `Backend returned code ${error.status}, ` +
          `body was: ${error.error}`);
      }
      return throwError(
        `${error.error}`);
    }
}
