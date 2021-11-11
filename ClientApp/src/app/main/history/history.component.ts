import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as signalR from '@microsoft/signalr';
import { UserService } from 'src/app/service/account/user.service';
@Component({
  selector: 'app-contact',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.scss']
})
export class HistoryComponent implements OnInit {

  list_hoadon:any;
  constructor(public http:HttpClient,private userService: UserService) {
    userService.checkLogin();
   }

  ngOnInit(): void {
    const clicks = localStorage.getItem('idUser');
    this.http.post("https://localhost:44302/api/hoadons/danhsachhoadon/",{
      idUser:clicks
    }).subscribe(
      res=>{
        this.list_hoadon=res;
      });
    const connection = new signalR.HubConnectionBuilder()
    .configureLogging(signalR.LogLevel.Information)
    .withUrl('https://localhost:44302/notify')
    .build();

  connection.start().then(function () {
    console.log('SignalR Connected!');
  }).catch(function (err) {
    return console.error(err.toString());
  });

  connection.on("BroadcastMessage", () => {
    this.http.post("https://localhost:44302/api/hoadons/danhsachhoadon/",{
      idUser:clicks
    }).subscribe(
      res=>{
        this.list_hoadon=res;
      });
  }
  )
}
}
