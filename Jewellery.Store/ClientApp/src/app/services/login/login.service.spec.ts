import { User } from './../../models/User';
import { LocalStorageService } from './../local-storage/local-storage.service';
import { TestBed } from '@angular/core/testing';

import { LoginService } from './login.service';

import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientModule } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
describe('LoginService', () => {
  let localStorageService = new LocalStorageService();
  let loggedIn = new BehaviorSubject<boolean>(false);

  beforeEach(() => TestBed.configureTestingModule({
    imports: [RouterTestingModule,HttpClientModule],
  }));

  it('should be created', () => {
    const service: LoginService = TestBed.get(LoginService);
    expect(service).toBeTruthy();
  });

  it("should logout", () => {
    const service: LoginService = TestBed.get(LoginService);
    service.logout();
    expect(localStorageService.getItem('user')).toBeNull();
    service.isLoggedIn.subscribe((resp) => {
      expect(resp).toBeFalse();
    });
  });

  it("should return user object", () => {
    const service: LoginService = TestBed.get(LoginService);
    service.getUserInfo(1).subscribe((resp) => {
      expect(resp).toBeInstanceOf(User);
    });
  });
});
