import {Component, OnInit} from '@angular/core';
import { navItems } from '../../_nav';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { LoginComponent } from '../../views/login/login.component';
import { UserService } from '../../views/account/user.service';
@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html'
})
export class DefaultLayoutComponent implements OnInit{
  public user : UserIdenity
  
  constructor(
    public userService : UserService,
    public router : Router,
    public http : HttpClient
  ){
  }
  onSelectedLogout(){
    this.userService.logout()
  }
  ngOnInit(): void {
  this.http.get("https://localhost:44302/api/Auth/AuthHistory").subscribe(
    res=>{
      this.user = res as UserIdenity
      console.log(this.user)
    },
    error=>{
      
    }
  );
  }

  public sidebarMinimized = false;
  public navItems = navItems;

  toggleMinimize(e) {
    this.sidebarMinimized = e;
  }
}
export class UserIdenity {
  firstName : string
  lastName : string
  imagePath : string
  email : string
} 

