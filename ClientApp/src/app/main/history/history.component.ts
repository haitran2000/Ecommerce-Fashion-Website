import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-contact',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.scss']
})
export class HistoryComponent implements OnInit {

  list_hoadon:any;
  constructor(public http:HttpClient) {
    const clicks = localStorage.getItem('idUser');
    this.http.post("https://localhost:44302/api/hoadons/danhsachhoadon/",{
      idUser:clicks
    }).subscribe(
      res=>{
        this.list_hoadon=res;
      });
   }

  ngOnInit(): void {
  }

}
