import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../../../../environments/environment';
import { ToastServiceService } from '../../shared/toast-service.service';
import { options } from 'fusioncharts';
@Injectable({
  providedIn: 'root'
})
export class DashboardService {


  constructor(private http: HttpClient) { }

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


 
  getCountProduct(): Observable<number> {
    return this.http.get<number>(environment.URL_API + "countentitys/countproduct")
      .pipe(
        catchError(this.handleError)
      )
  }

  getCountOrder(): Observable<number> {
    return this.http.get<number>(environment.URL_API + "countentitys/countorder")
      .pipe(
        catchError(this.handleError)
      )
  }

  getCountUser(): Observable<number> {
    return this.http.get<number>(environment.URL_API + "countentitys/countuser")
      .pipe(
        catchError(this.handleError)
      )
  }

  getCountTotalMoney(): Observable<number> {
    return this.http.get<number>(environment.URL_API + "countentitys/countmoney")
      .pipe(
        catchError(this.handleError)
      )
  }

  getThongKeThang(): Observable<any> {
    return this.http.get<any>(environment.URL_API + "dashboard/thongkethang")
      .pipe(
        catchError(this.handleError)
      )
  }

  getSanPhamBanChay():Observable<any>{
    return this.http.get<any>(environment.URL_API+"CountEntitys/getsanphambanchay",{headers:{'Content-Type':'application/json; charset=utf-8'}})
  }
  getSoLanSanPhamXuatHienTrongDonHang():Observable<any>{
    return this.http.get<any>(environment.URL_API+"dashboard/solanxuathientrongdonhang")
  }
  getSanPhamDoanhThuTop():Observable<any>{
     return this.http.get<any>(environment.URL_API+"dashboard/sanphamloinhattop") 
  }
}
