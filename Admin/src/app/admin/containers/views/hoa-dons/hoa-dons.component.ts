import { DatePipe } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Data, Router } from '@angular/router';
import { ToastServiceService } from '../../shared/toast-service.service';

import { HoaDonComponent } from './hoa-don/hoa-don.component';
import {  HoaDon, HoaDonService } from './hoadon.service';

@Component({
  selector: 'app-hoa-dons',
  templateUrl: './hoa-dons.component.html',
  styleUrls: ['./hoa-dons.component.scss'],
  providers: [DatePipe]
})
export class HoaDonsComponent implements OnInit {

  @ViewChild(MatSort) sort: MatSort;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  productList: any[];
  constructor(public service: HoaDonService,
    public router: Router,
    public http: HttpClient,
    public dialog: MatDialog,
    public serviceToast: ToastServiceService,
  ) { }
  displayedColumns: string[] = ['id', 'id_User', 'ngayTao', 'ghiChi', 'tongTien', 'actions'];


  public hoadon: HoaDon
  ngOnInit(): void {
    this.service.getAllHoaDons();
  }

  ngAfterViewInit(): void {
    this.service.dataSource.sort = this.sort;
    this.service.dataSource.paginator = this.paginator;

  }

  onModalDialog() {
    this.service.hoadon = new HoaDon()
    this.dialog.open(HoaDonComponent)
  }

  routeChiTiet(selectedRecord: HoaDon) {
    this.service.hoadon = Object.assign({}, selectedRecord)
    this.router.navigate(['admin/hoadon/detail/' + this.service.hoadon.id])
  }
  doFilter = (value: string) => {
    this.service.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  populateForm(selectedRecord: HoaDon) {

    this.service.hoadon = Object.assign({}, selectedRecord)
    this.dialog.open(HoaDonComponent)
  }
  exports() {
    this.service.generateExcel(this.service.dataBills)
  }
  clickDelete(id) {
    if (confirm('Bạn có chắc chắn xóa bản ghi này không ??')) {
      this.service.delete(id).subscribe(
        res => {
          this.service.getAllHoaDons()
          this.serviceToast.showToastXoaThanhCong();
        },
        err => {
          this.serviceToast.showToastXoaThatBai();
        }
      )
    }
  }
}
