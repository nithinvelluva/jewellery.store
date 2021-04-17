import { LoginService } from './../services/login/login.service';
import { Component, OnInit } from '@angular/core';
import { CredentialsRequest } from '../models/CredentialsRequest';
import { Router } from '@angular/router'; 
import { LocalStorageService } from '../services/local-storage/local-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  Credential: CredentialsRequest;
  localStorageUserKey="user";
  hasValidationErrors:boolean;
  hasRequiredErrors: boolean;
  constructor(private _localStorageService: LocalStorageService,private router: Router, private _loginService:LoginService) {
    this.Credential = new CredentialsRequest();
   }

  ngOnInit(): void {
    var user = this._localStorageService.getItem(this.localStorageUserKey);
    if(user) this.router.navigate(['/']);
  }

  signIn() {
    this.hasValidationErrors = false;
    this.hasRequiredErrors = false;
    if(this.Credential.Username && this.Credential.Password){
      var credentialsRequest = new CredentialsRequest();
      credentialsRequest.Username = this.Credential.Username;
      credentialsRequest.Password = this.Credential.Password;
  
      this._loginService.signIn(credentialsRequest).subscribe((data: any) => {      
        console.log('from service' ,data);
        if(data){
          this._localStorageService.setItem('user',JSON.stringify(data));
          this._loginService.setLoggedIn = true;
          this.router.navigate(['/']);
        }
        else{
          this.hasValidationErrors = true;
        }
      });
    }
    else{
      this.hasRequiredErrors = true;
    }    
  }  
}
