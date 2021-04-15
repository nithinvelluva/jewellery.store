import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { PricecalculatorComponent } from './pricecalculator/pricecalculator.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginService } from './services/login/login.service';
import { AuthGuard } from './auth/auth.gurad';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    PricecalculatorComponent,
    NavMenuComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    NgbModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: 'login', component: LoginComponent, pathMatch: 'full' },
      { path: '', component: PricecalculatorComponent,canActivate:[AuthGuard] }
    ])    
  ],
  providers: [LoginService,AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
