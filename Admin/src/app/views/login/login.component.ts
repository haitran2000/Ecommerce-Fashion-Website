import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router, RouterModule } from '@angular/router';
import { Subscription } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';
@Component({
  selector: 'app-dashboard',
  templateUrl: 'login.component.html'
})

export class LoginComponent  implements OnInit{
  private subscription: Subscription;
  brandNew: boolean;
  errors: string;
  isRequesting: boolean;
  submitted: boolean = false;
  credentials: Credentials = { email: '', password: '' };
  constructor( public router : Router,private activatedRoute: ActivatedRoute , public http : HttpClient){
    
  }
  private loggedIn = false;
  
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
      this.http.post("https://localhost:44302/api/auth/login",form).subscribe(
        res=>{
          this.router.navigate(['/dashboard']);             
        },
        error=>{

        }
      )

    }
  }

 export interface Credentials {
  email: string;  
  password: string;
}