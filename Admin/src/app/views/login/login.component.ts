import { Component, Injectable, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router, RouterModule } from '@angular/router';
import { Subscription } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';
import { UserService } from '../account/user.service';
@Component({
  selector: 'app-dashboard',
  templateUrl: 'login.component.html'
})
@Injectable()
export class LoginComponent  implements OnInit{
  private subscription: Subscription;
  brandNew: boolean;
  errors: string;
  isRequesting: boolean;
  submitted: boolean = false;
  credentials: Credentials = { email: '', password: '' };
  constructor( public router : Router,private activatedRoute: ActivatedRoute , public http : HttpClient, public userService : UserService){
    
  }
  private loggedIn = false;
  isLoggedIn() {
    return this.loggedIn;
  }  
  public newForm: FormGroup;
  ngOnInit(){
    this.newForm = new FormGroup({
      userName : new FormControl(null),
      passWord : new FormControl(null),
    })
    this.subscription = this.activatedRoute.queryParams.subscribe(
      (param: any) => {
         this.brandNew = param['brandNew'];   
         this.credentials.email = param['email'];         
      });      
  }
  onLogOut(){
    localStorage.removeItem('auth_token');
    this.loggedIn = false
  }
  onLogin(){
    this.router.navigate(['/register']);
  }
onSubmit = (data) =>{
  let form = new FormData();
  form.append('UserName', data.userName);
  form.append('Password',data.passWord);
    this.submitted = true;
    this.isRequesting = true;
    this.errors='';
    this.userService.login(data.userName,data.passWord)
    }
  
  }

 export interface Credentials {
  email: string;  
  password: string;
}