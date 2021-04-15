import { LoginService } from './../services/login/login.service';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor( private routes: Router,private loginService:LoginService){}
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
      //debugger;
      if (localStorage.getItem('user') != null) {
        this.loginService.setLoggedIn = true;
        return true;
      }
      else {
        this.routes.navigate(['/login']);
        return false;
      }
  }  
}