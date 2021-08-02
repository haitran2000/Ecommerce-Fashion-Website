import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ChartSecondService {

  constructor(private http: HttpClient) { }
  getKhachHangMuaNhieuNhat():Observable<any>{
    return this.http.get<any>(environment.URL_API+"CountEntitys/getkhachhangmuanhieunhat") 
  }

  getNam2021DoanhSo():Observable<any>{
    return this.http.get<any>(environment.URL_API+"CountEntitys/nam2021")
  }
  getNam2021SoLuong():Observable<any>{
    return this.http.get<any>(environment.URL_API+"CountEntitys/Soluongsanphambanratrongnam")
  }
  getSoLuongTon():Observable<any>{
    return this.http.get<any>(environment.URL_API+"CountEntitys/soluongton")
  }



  ////////////////////////////////////
  getTopBienTheDoanhThu():Observable<any>{
    return this.http.get<any>(environment.URL_API+"dashboard/topbienthedoanhthu")
  }
  getTopSoLuongTon():Observable<any>{
    return this.http.get<any>(environment.URL_API+"dashboard/topsoluongton")
  }
  getThongKeThang(): Observable<any> {
    return this.http.get<any>(environment.URL_API + "dashboard/topthongkethang")
  }
  getSoLanSanPhamXuatHienTrongDonHang():Observable<any>{
    return this.http.get<any>(environment.URL_API+"dashboard/topsolanxuathientrongdonhang")
  }
  getSanPhamDoanhThuTop():Observable<any>{
     return this.http.get<any>(environment.URL_API+"dashboard/topsanphamloinhattop") 
  }
  getTopNhanHieuDoanhThu():Observable<any>{
    return this.http.get<any>(environment.URL_API+"dashboard/topnhanhieubanchaynhattrongnam2021")
  }


  dataThongKeNgay: any
  public dataSourceNgay: any = {
    chart: {
      caption: 'Doanh thu',
      xAxisName: 'Ngày',
      yAxisName: 'Số tiền thu về',
      numberSuffix: '',
      theme: 'umber'
    },
    data: [
      { label: "", value: "" },
      { label: "", value: "" },
      { label: "", value: "" },
      { label: "", value: "" },
      { label: "", value: "" },
      { label: "", value: "" },
      { label: "", value: "" },
      { label: "", value: "" },
      { label: "", value: "" },
      { label: "", value: "" },
      { label: "", value: "" },
      { label: "", value: "" },
      { label: "", value: "" }
    ]
  }

}
