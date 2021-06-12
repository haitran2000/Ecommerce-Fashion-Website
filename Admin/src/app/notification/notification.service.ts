import { HttpClient, HttpHeaders } from '@angular/common/http';  
import { Injectable } from '@angular/core';  
import { Observable, throwError } from 'rxjs';  
import { catchError } from 'rxjs/operators';  

import { NotificationCheckOutCountResult, NotificationCountResult, NotificationResult,NotificationCheckOutResult } from './notification';  
  
@Injectable({  
  providedIn: 'root'  
})  
export class NotificationService {  
  
  private notificationsUrl = 'https://localhost:5001/api/notifications';  
  
  constructor(private http: HttpClient) { }  
  
  getNotificationCount(): Observable<NotificationCountResult> {  
    const url = 'https://localhost:5001/api/notifications/notificationcount';  
    return this.http.get<NotificationCountResult>(url)  
      .pipe(  
        catchError(this.handleError)  
      );  
  }  
  
  getNotificationMessage(): Observable<Array<NotificationResult>> {  
    const url = `${this.notificationsUrl}/notificationresult`;  
    return this.http.get<Array<NotificationResult>>(url)  
      .pipe(  
        catchError(this.handleError)  
      );  
  }  
  
  deleteNotifications(): Observable<{}> {  
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });  
    const url = `${this.notificationsUrl}/deletenotifications`;  
    return this.http.delete(url, { headers: headers })  
      .pipe(  
        catchError(this.handleError)  
      );  
  }  
  
  private handleError(err) {  
    let errorMessage: string;  
    if (err.error instanceof ErrorEvent) {  
      errorMessage = `An error occurred: ${err.error.message}`;  
    } else {  
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;  
    }  
    console.error(err);  
    return throwError(errorMessage);  
  }  

  getNotificationCheckOutCount(): Observable<NotificationCheckOutCountResult> {  
    const url = 'https://localhost:5001/api/notificationcheckout/notificationcheckoutcount';  
    return this.http.get<NotificationCheckOutCountResult>(url)  
      .pipe(  
        catchError(this.handleError)  
      );  
  }  
  getNotificationCheckOutMessage(): Observable<Array<NotificationCheckOutResult>> {  
    const url = 'https://localhost:5001/api/notificationcheckout/notificationcheckoutresult';
    return this.http.get<Array<NotificationCheckOutResult>>(url)  
      .pipe(  
        catchError(this.handleError)  
      );  
  }  
}  