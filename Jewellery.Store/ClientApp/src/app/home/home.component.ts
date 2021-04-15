import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CredentialsRequest } from '../models/CredentialsRequest';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  Credential: CredentialsRequest;
  _http: HttpClient;
  _baseUrl: string;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.Credential = new CredentialsRequest();
    this._http = http;
    this._baseUrl = baseUrl;
  }
  signIn() {

  }
  ngOnInit() {
  }
}
