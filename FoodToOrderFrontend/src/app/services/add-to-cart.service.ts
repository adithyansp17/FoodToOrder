import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { Carts } from '../models/cart';
import { CartDish } from '../models/cartdish';

@Injectable({
  providedIn: 'root',
})
export class AddToCartService {
  constructor(private httpClient: HttpClient) {}

  baseUrl: string = 'https://localhost:7104/api';

  httpHeader = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  httpError(error: HttpErrorResponse) {
    let msg = '';
    if (error.error instanceof ErrorEvent) {
      msg = error.error.message;
    } else {
      msg = 'Error code:${error.status}\nMessage:${error.message}';
    }
    return throwError(msg);
  }

  getCart(): Observable<Carts[]> {
    return this.httpClient
      .get<Carts[]>(this.baseUrl + '/Carts')
      .pipe(catchError(this.httpError));
  }

  getCartById(rid: string): Observable<Carts> {
    return this.httpClient
      .get<Carts>(this.baseUrl + '/Carts/' +rid)
      .pipe(catchError(this.httpError));
  }

  updateCart(rid: string, updatedCartData: any): Observable<Carts> {
    // updatedCartData.cartdish.forEach(list=>{
    //   list.dish = null
    // })

    //console.log("Updated data: ",JSON.stringify(updatedCartData))
  
   
    
    return this.httpClient
      .put<Carts>(
        this.baseUrl + '/Carts/' + rid,
        JSON.stringify(updatedCartData),
        this.httpHeader
      )
      .pipe(catchError(this.httpError));
  }

  AddCart(updatedCartData: Carts): Observable<Carts> {
    console.log(JSON.stringify(updatedCartData))
    return this.httpClient
      .post<Carts>(this.baseUrl + '/Carts', JSON.stringify(updatedCartData), this.httpHeader)
      .pipe(catchError(this.httpError));
  }

  DeleteCart(id: string): Observable<any> {
    return this.httpClient
      .delete<Carts>(this.baseUrl + '/Carts/' + id)
      .pipe(catchError(this.httpError));
  }

  
}
