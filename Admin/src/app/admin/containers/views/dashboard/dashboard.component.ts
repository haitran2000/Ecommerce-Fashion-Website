import { Component, OnInit } from '@angular/core';
import { getStyle, hexToRgba } from '@coreui/coreui/dist/js/coreui-utilities';
import { CustomTooltips } from '@coreui/coreui-plugin-chartjs-custom-tooltips';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../../environments/environment';
import { FormControl, FormGroup } from '@angular/forms';
import { error } from 'node:console';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import * as signalR from '@microsoft/signalr';
import { DashboardService } from './dashboard.service';
import { ToastServiceService } from '../../shared/toast-service.service';
@Component({
  templateUrl: 'dashboard.component.html'
})
export class DashboardComponent implements OnInit {
  public newBlogForm: FormGroup;
  errorMessage = '';
  public dataSource: any = {
    chart: {
      caption: 'Doanh thu trong năm 2021',
      xAxisName: 'Tháng',
      yAxisName: 'Số tiền thu về',
      numberSuffix: '',
      theme: 'fusion'
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
      { label: "", value: "" }
    ]
  }
    ;


  ///

  public dataSourceNgay: any = {
    chart: {
      caption: 'Doanh thu',
      xAxisName: 'Ngày',
      yAxisName: 'Số tiền thu về',
      numberSuffix: '',
      theme: 'fusion'
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

  //

  ///

  public dataSourceSoLanXuatHien: any = {
    chart: {
      caption: 'Số lần xuất hiện',
      xAxisName: 'Tên sản phẩm',
      yAxisName: 'Số lần xuất hiện trong đơn hàng',
      numberSuffix: '',
      theme: 'fusion'
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
      { label: "", value: "" }
    ]
  }


  public dataSourceDoanhThu: any = {
    chart: {
      caption: 'Số lần xuất hiện',
      xAxisName: 'Tên sản phẩm',
      yAxisName: 'Số lần xuất hiện trong đơn hàng',
      numberSuffix: '',
      theme: 'fusion'
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
      { label: "", value: "" }
    ]
  }
  ngOnInit(): void {
    this.getTop10SanPhamLoiNhats()
    this.getSoLanXuatHienTrongDonHang()
    this.getCountProduct()
    this.getCountOrder()
    this.getCountUser();
    this.getCountTotalMoney();
    this.getThongKeThang();
    this.getStringSanPhamBanChay()
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
      this.getStringSanPhamBanChay();
    });
    connection.on("BroadcastMessage", () => {
      this.getCountProduct();
    });
    connection.on("BroadcastMessage", () => {
      this.getCountUser();
    });

    connection.on("BroadcastMessage", () => {
      this.getCountTotalMoney();
    });
    connection.on("BroadcastMessage", () => {
      this.getCountOrder();
      this.toast.showToastDonHangTaoThanhCong()
    });
    connection.on("BroadcastMessage", () => {
      this.getSoLanXuatHienTrongDonHang()
    });
    connection.on("BroadcastMessage", () => {
      this.getThongKeThang();
    });
    connection.on("BroadcastMessage",()=>{
      this.getTop10SanPhamLoiNhats()
    })
    this.newBlogForm = new FormGroup({
      Thang: new FormControl(null,
        [
        ]),
    });



  }
  constructor(
    public http: HttpClient,
    public service: DashboardService,
    private toast: ToastServiceService
  ) {
  }
  getThongKeThang() {
    this.service.getThongKeThang().subscribe(
      (result: any) => {
        this.dataThongKe = result as any
        console.log(this.dataThongKe);
        for (var i = 0; i < this.dataThongKe.length; i++) {
          this.dataSource.data[this.dataThongKe[i].month].label = this.dataThongKe[i].month as any
          this.dataSource.data[this.dataThongKe[i].month].value = this.dataThongKe[i].revenues as any
        }
      },
      error => {
        this.errorMessage = <any>error
      }
    )
  }


  onSubmit = (data) => {
    const formData = new FormData();
    formData.append("month", data.Thang)
    this.http.post(environment.URL_API + "dashboard/thongkengaytheothang", formData).subscribe(
      (result: any) => {
        this.dataThongKeNgay = result as any
        if (this.dataThongKeNgay.length != 0) {
          this.dataThongKeNgay = result as any
          console.log(this.dataThongKeNgay);
          for (var i = 0; i < this.dataThongKeNgay.length; i++) {
            this.dataSourceNgay.data[i].label = this.dataThongKeNgay[i].ngay as any
            this.dataSourceNgay.data[i].value = this.dataThongKeNgay[i].revenues as any

          }
        }
        else {
          for (var i = 0; i < 31; i++) {
            this.dataSourceNgay.data[i].label = ""
            this.dataSourceNgay.data[i].value = ""
          }


        }

      },
      error => {
        this.errorMessage = <any>error
      }
    )
  }
  dataclone: any
  dataThongKe: any
  dataThongKeNgay: any
  countProduct: number;
  countOrder: number;
  countUser: number;
  countTotalMoney: number;
  sanPhamBanChay: any;
  soLanXuatHien: any;
  lengthArr: number;
  doanhthucaonhat:any;
  getCountProduct() {
    this.service.getCountProduct().subscribe(
      result => {
        this.countProduct = result as number
      },
      error => {
        this.errorMessage = <any>error
      }
    )
  }

  getCountOrder() {
    this.service.getCountOrder().subscribe(
      result => {
        this.countOrder = result as number
      },
      error => this.errorMessage = <any>error
    )

  }

  getCountUser() {
    this.service.getCountUser().subscribe(
      result => {
        this.countUser = result as number
      },
      error => this.errorMessage = <any>error
    )
  }

  getCountTotalMoney() {
    this.service.getCountTotalMoney().subscribe(
      result => {
        this.countTotalMoney = result as number
      },
      error => {
        this.errorMessage = <any>error
      }
    )
  }

  getStringSanPhamBanChay() {
    this.service.getSanPhamBanChay().subscribe(
      result => {
        this.sanPhamBanChay = result as any

      },
      error => {
        this.errorMessage = <any>error
        console.log(error);
      }
    )
  }

  getSoLanXuatHienTrongDonHang() {
    this.service.getSoLanSanPhamXuatHienTrongDonHang().subscribe(
      result => {
        this.soLanXuatHien = result as any
        for (var i = 0; i < this.soLanXuatHien.length; i++) {
          this.dataSourceSoLanXuatHien.data[i].label = this.soLanXuatHien[i].tenSP
          this.dataSourceSoLanXuatHien.data[i].value = this.soLanXuatHien[i].soLanXuatHienTrongDonHang
        }

      },
      error => {
        this.errorMessage = <any>error
        console.log(error);
      }
    )
  }

  getTop10SanPhamLoiNhats(){
    this.service.getSanPhamDoanhThuTop().subscribe(
      result=>{
        this.doanhthucaonhat = result as any
        for (var i = 0; i < this.doanhthucaonhat.length; i++) {
          this.dataSourceDoanhThu.data[i].label = this.doanhthucaonhat[i].tenSP
          this.dataSourceDoanhThu.data[i].value = this.doanhthucaonhat[i].doanhSoCaoNhat
        }
      }
    )
  }
}