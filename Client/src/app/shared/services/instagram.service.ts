import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InstagramService {

  // Initialize
  constructor(private http: HttpClient) { }

  // Instagram Array
  public get getInstagramData() {
    return this.http.get('https://api.instagram.com/v1/users/self/media/recent/?access_token=' + environment.instagram_token + '&count=15');
  }

}
