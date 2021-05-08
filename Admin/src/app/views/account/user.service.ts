import { Injectable } from '@angular/core';
import {  HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { BaseService } from './base.service';

//import * as _ from 'lodash';

// Add the RxJS Observable operators we need in this app.


@Injectable()

export class UserService extends BaseService  {

  baseUrl: string = '';

  // Observable navItem source
  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  // Observable navItem stream
  authNavStatus$ = this._authNavStatusSource.asObservable();

  private loggedIn = false;

  constructor(private http: HttpClient) {
    super();
    this.loggedIn = !!localStorage.getItem('auth_token');
    // ?? not sure if this the best way to broadcast the status but seems to resolve issue on page refresh where auth status is lost in
    // header component resulting in authed user nav links disappearing despite the fact user is still logged in
    this._authNavStatusSource.next(this.loggedIn);
    this.baseUrl = "https://localhost:44302/api/"
  }

    register(email: string, password: string, firstName: string, lastName: string,location: string) {
    let body = JSON.stringify({ email, password, firstName, lastName,location });
        return this.http.post('https://localhost:44302/api/sanphams',body);
    }  


   login(userName, password) {
    
    return this.http
.post(
      this.baseUrl + '/auth/login',
      JSON.stringify({ userName, password }),
      { headers: new HttpHeaders({'Content-Type':'application/json'}
      )}).subscribe(
        (res : any)=> {
          localStorage.setItem('auth_token', res.auth_token);
          this.loggedIn = true;
          this._authNavStatusSource.next(true);
          return true;
      })
  }

  logout() {
    localStorage.removeItem('auth_token');
    this.loggedIn = false;
    this._authNavStatusSource.next(false);
  }

  isLoggedIn() {
    return this.loggedIn;
  }  
}
export interface UserRegistration {
  email: string;  
  password: string;
  firstName: string;
  lastName:  string;
  location: string;
}