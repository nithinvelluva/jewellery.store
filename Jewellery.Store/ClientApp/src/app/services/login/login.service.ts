import { CredentialsRequest } from './../../models/CredentialsRequest';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { User } from 'src/app/models/User';
import { LocalStorageService } from '../local-storage/local-storage.service';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private loggedIn = new BehaviorSubject<boolean>(false);
  userLocalStorageKey = 'user';
  _http:HttpClient;
  _baseUrl:string;

  // Http Options
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  get isLoggedIn() {
    return this.loggedIn.asObservable();
  }
  
  public set setLoggedIn(value : boolean) {
    this.loggedIn.next(value);
  }

  constructor(
    private router: Router,
    private localStorageService: LocalStorageService,
    http: HttpClient, 
    // @Inject('BASE_URL') baseUrl: string
  ) {
    this._http = http;
		this._baseUrl = "";    
  }  

  getUserInfo(userid:number) : Observable<User>{
    return this._http.get<User>(this._baseUrl + 'api/Login/' + userid)
    .pipe(      
      catchError(this.httpError)
    )
  }

  signIn(credentialsRequest:CredentialsRequest){
    return this._http.post<any>(this._baseUrl + 'api/Login',credentialsRequest,this.httpOptions)
    .pipe(      
      catchError(this.httpError)
    )
  }

  logout() {
    this.localStorageService.removeItem(this.userLocalStorageKey);
    this.loggedIn.next(false);
    this.router.navigate(['/login']);
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