import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { environment } from '../../../../../../environments/environment';


import { CTHDViewModel, HoaDonService } from '../hoadon.service';

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
              public dialog: MatDialog,
             ) { }
  displayedColumns: string[] = ['IdCTHD', 'tenSanPham','tenSize','tenMau','gia','soLuong','thanhTien','id_HoaDon'];


  public cthdViewModel : CTHDViewModel
  public data : any=[]
  ngOnInit(): void {
    this.service.getHoaDon(this.service.hoadon.id);
  
    
  }
  ngAfterViewInit(): void {
    this.service.dataSource2.sort = this.sort;
    this.service.dataSource2.paginator = this.paginator;
    console.log(this.service.dataOneBill);
  }


getIdThisHoaDon(){
  return this.service.hoadon.id
}
getTongTienThisHoaDon(){
  return this.service.hoadon.tongTien
}
 doFilter = (value: string) => {
  this.service.dataSource2.filter = value.trim().toLocaleLowerCase();
}

  
 
}
