import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
@Component({
  selector: 'app-contact',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.scss']
})
export class HistoryComponent implements OnInit {

  list_hoadon:any;
  constructor(public http:HttpClient) {
    const clicks = localStorage.getItem('idUser');
    this.http.post(environment.URL_API+"hoadons/danhsachhoadon/",{
      idUser:clicks
    }).subscribe(
      res=>{
        this.list_hoadon=res;
      });
   }

  ngOnInit(): void {
  }

}
