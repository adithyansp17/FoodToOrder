import { Injectable } from '@angular/core';
import { Dishes } from '../models/dishes';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DishService {
    arrDish:Dishes[]
  constructor(private httpClient: HttpClient) {
    this.arrDish=[]
    //   new Dishes(1,"Burger",120,1,"../../../assets/images/images.jpg"),
    //   new Dishes(2,"Sandwich",50,1,"../../../assets/images/images (1).jpg"),
    //   new Dishes(3,"Cola",20,1,"../../../assets/images/images (2).jpg"),
    //   new Dishes(1,"Rolls",100,2,"../../../assets/images/images (3).jpg"),
    //   new Dishes(2,"Cream",40,2,"../../../assets/images/images (4).jpg"),
    //   new Dishes(1,"Masaladosa",30,3,"../../../assets/images/images (5).jpg"),
    //   new Dishes(2,"Tea",10,3,"../../../assets/images/images (6).jpg"),
    //   new Dishes(3,"Rice",50,3,"../../../assets/images/images (7).jpg")
    // ]
   }

   baseUrl: string = "https://localhost:7104/api";

  httpHeader = {
    headers: new HttpHeaders({
      "Content-Type": "application/json",
    }),
  };

  httpError(error: HttpErrorResponse) {
    let msg = "";
    if (error.error instanceof ErrorEvent) {
      msg = error.error.message;
    } else {
      msg = "Error code:${error.status}\nMessage:${error.message}";
    }
    return throwError(msg);
  }
  getDishes():Observable<Dishes[]>{
    return this.httpClient
      .get<Dishes[]>(this.baseUrl + "/Dish" )
      .pipe(catchError(this.httpError));
  }
  
   getDishById(did: string) : Observable<Dishes>{
    return this.httpClient
      .get<Dishes>(this.baseUrl + "/Dish/" + did)
      .pipe(catchError(this.httpError));
  }

  deleteAddress(id:string): Observable<any> {
    return this.httpClient
      .delete<any>(this.baseUrl + "/Address/" + id)
      .pipe(catchError(this.httpError));
  }

  deleteDish(id:string): Observable<any> {
    return this.httpClient
      .delete<any>(this.baseUrl + "/Dish/" + id)
      .pipe(catchError(this.httpError));
  }

}
