import { LoginService } from './../services/login/login.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  isLoggedIn: Observable<boolean>;

  constructor(private loginService: LoginService) { }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  ngOnInit() {
    this.isLoggedIn = this.loginService.isLoggedIn;
  }

  onSignOut() {
    this.loginService.logout();
  }
}
