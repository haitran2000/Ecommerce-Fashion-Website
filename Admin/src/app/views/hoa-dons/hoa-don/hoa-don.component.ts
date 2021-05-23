import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { CTHDViewModel, HoaDon } from '../hoa-dons.component';
import { HoaDonService } from '../hoadon.service';

@Component({
  selector: 'app-hoa-don',
  templateUrl: './hoa-don.component.html',
  styleUrls: ['./hoa-don.component.scss']
})
export class HoaDonComponent implements OnInit {

  @ViewChild(MatSort) sort: MatSort;
 
  @ViewChild(MatPaginator) paginator: MatPaginator;
  productList: any[];
  constructor(public service: HoaDonService,
              public router : Router,
              public http: HttpClient,
              public dialog: MatDialog,) { }


              displayedColumns: string[] = ['IdCTHD', 'tenSanPham','hinhAnh','tenSize','tenMau','gia','soLuong','thanhTien','id_HoaDon'];


  public cthdViewModel : CTHDViewModel
  ngOnInit(): void {
    this.service.getHoaDon(this.service.hoadon.id);
  }
  ngAfterViewInit(): void {
    this.service.dataSource.sort = this.sort;
    this.service.dataSource.paginator = this.paginator;
  }

getExportFile(){
  this.http.get("https://localhost:44302/api/hoadons/exportExcel/"+this.service.hoadon.id);
}

getIdThisHoaDon(){
  return this.service.hoadon.id
}
getTongTienThisHoaDon(){
  return this.service.hoadon.tongTien
}
 doFilter = (value: string) => {
  this.service.dataSource.filter = value.trim().toLocaleLowerCase();
}

  
 
}
