import { PriceRequest } from './../../models/PriceRequest';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {
  _http:HttpClient;
  _baseUrl:string;

  // Http Options
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  constructor(    
    http: HttpClient, 
    // @Inject('BASE_URL') baseUrl: string
  ) {
    this._http = http;
		this._baseUrl = "";    
  } 

  calculatePrice(priceResult:PriceRequest){
    return this._http.post<any>(this._baseUrl + 'api/PriceCalculator',priceResult,this.httpOptions)
    .pipe(      
      catchError(this.httpError)
    )
  }

  httpError(error) {
    let msg = '';
    if(error.error instanceof ErrorEvent) {
      // client side error
      msg = error.error.message;
    } else {
      // server side error
      msg = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(msg);
    return throwError(msg);
  } 
}
