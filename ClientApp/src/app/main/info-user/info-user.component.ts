import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-info-user',
  templateUrl: './info-user.component.html',
  styleUrls: ['./info-user.component.scss']
})
export class InfoUserComponent implements OnInit {

  user:any;
  constructor(public http:HttpClient) {
    this.http.get("https://localhost:44302/api/Auth/AuthHistory").subscribe(
    res=>{
      this.user = res;
    },
    error=>{

    }
    );
   }

  ngOnInit(): void {
  }

}
