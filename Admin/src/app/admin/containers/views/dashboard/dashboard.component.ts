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
import {MatDialog} from '@angular/material/dialog';
import { SelectMonthComponent } from './select-month/select-month.component';
@Component({
  templateUrl: 'dashboard.component.html'
})
export class DashboardComponent implements OnInit {

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

 

  //

  ///

  public dataSourceSoLanXuatHien: any = {
    chart: {
      caption: 'Số lượng đã bán',
      xAxisName: 'Tên sản phẩm',
      yAxisName: 'Số lượng đã bán',
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
      caption: 'sản phẩm đạt top doanh số cao nhất',
      xAxisName: 'Tên sản phẩm',
      yAxisName: 'doanh thu',
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
    this.getKhachHangMuaNhieuNhat();
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
    connection.on("BroadcastMessage",()=>{
      this.getKhachHangMuaNhieuNhat()
    })
  



  }
  constructor(
    public http: HttpClient,
    public service: DashboardService,
    private toast: ToastServiceService,
    public dialog: MatDialog
  ) {
  }
  openDialog() {
    const dialogRef = this.dialog.open(SelectMonthComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
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
  khachhangmuanhieunhat:any;
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

  getKhachHangMuaNhieuNhat(){
    this.service.getKhachHangMuaNhieuNhat().subscribe(
      result=>{
        this.khachhangmuanhieunhat = result as any
      },
      error=>{
        this.errorMessage = <any>error
        console.log(error);
      }
    )
  }
}