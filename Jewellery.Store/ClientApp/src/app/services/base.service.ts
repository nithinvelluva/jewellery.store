import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseService {  

  public _http:HttpClient;
  public _baseUrl:string;
  public httpHeader = new HttpHeaders({
      'Content-Type': 'application/json'
    });  
  constructor(    
    public  http: HttpClient, 
    // @Inject('BASE_URL') baseUrl: string
  ) {
    this._http = http;
		this._baseUrl = "";    
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