import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public register:any;
  userFormGroup: FormGroup
  public hide: boolean = true;
  username:any;
  private _unsubscribeAll: Subject<any>;
  constructor(public http : HttpClient, public router: Router,private _formBuilder: FormBuilder) {
    this.register={};
    this._unsubscribeAll = new Subject();

   }
   check(){
    if(this.userFormGroup.value.Password!=this.userFormGroup.value.RePassword)
    {
     Swal.fire("Mật khẩu không trùng nhau", '', 'warning').then(function () {
     }
     )
    }
    else
    {
      this.registerAccount()
    }

   }
   registerAccount(){
    this.http.post("https://localhost:44302/api/auth/registerCustomer",{
      data:this.userFormGroup.value
      }).subscribe(
    )
    Swal.fire("Đăng ký thành công", '', 'success').then(function () {
    }
    )
  }

  ngOnInit(): void {
    this.userFormGroup = this._formBuilder.group({

      FirstName: ['', [Validators.required]],
      LastName: ['', Validators.required],
      Email: ['', Validators.required],
      Password: ['', Validators.required],
      RePassword: ['', Validators.required],
    });
    this.userFormGroup.get('Password').valueChanges
            .pipe(takeUntil(this._unsubscribeAll))
            .subscribe(() => {
                this.userFormGroup.get('RePassword').updateValueAndValidity();
            });
  }
  ngOnDestroy(): void {
    // Unsubscribe from all subscriptions
    this._unsubscribeAll.next();
    this._unsubscribeAll.complete();
}




}
