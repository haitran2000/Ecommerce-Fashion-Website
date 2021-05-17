import {Component, OnInit} from '@angular/core';
import { navItems } from '../../_nav';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { LoginComponent } from '../../views/account/login/login.component';
import { UserService } from '../../views/account/user.service';
import { ModalService } from '../../modal/modal.service';  
import * as signalR from '@microsoft/signalr';  
import { NotificationCountResult, NotificationResult } from '../../Notification/notification';  
import { NotificationService } from '../../Notification/notification.service';  
@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html'
})
export class DefaultLayoutComponent implements OnInit{
  public user : UserIdenity
  notification: NotificationCountResult;  
  messages: Array<NotificationResult>;  
  errorMessage = '';  
  
  constructor(
    private notificationService: NotificationService, 
    private modalService: ModalService,
    public userService : UserService,
    public router : Router,
    public http : HttpClient
  ){
  }
  isExpanded = false;  
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
  this.getNotificationCount();  
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
    this.getNotificationCount();  
  });  
  }

  collapse() {  
    this.isExpanded = false;  
  }  
  
  toggle() {  
    this.isExpanded = !this.isExpanded;  
  }  
  
  getNotificationCount() {  
    this.notificationService.getNotificationCount().subscribe(  
      notification => {  
        this.notification = notification;  
      },  
      error => this.errorMessage = <any>error  
    );  
  }  
  
  getNotificationMessage() {  
    this.notificationService.getNotificationMessage().subscribe(  
      messages => {  
        this.messages = messages;  
      },  
      error => this.errorMessage = <any>error  
    );  
  }  
  
  deleteNotifications(): void {  
    if (confirm(`Are you sure want to delete all notifications?`)) {  
      this.notificationService.deleteNotifications()  
        .subscribe(  
          () => {  
            this.closeModal();  
          },  
          (error: any) => this.errorMessage = <any>error  
        );  
    }  
  }  
  openModal() {  
    this.getNotificationMessage();  
    this.modalService.open('custom-modal');  
  }  
  
  closeModal() {  
    this.modalService.close('custom-modal');  
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

