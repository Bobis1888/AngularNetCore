import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse} from '@angular/common/http';
import { User } from '../models/User';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable()
export class AccountService {

    private url = '/api/account';

    constructor(private http: HttpClient) {}

    login(user: User): Observable<User> {
      return this.http.post<User>(this.url + '/login', user).pipe(catchError(this.handleError));
    }

    reg(user: User): Observable<User> {
      return this.http.post<User>(this.url + '/registration', user).pipe(catchError(this.handleError));
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
