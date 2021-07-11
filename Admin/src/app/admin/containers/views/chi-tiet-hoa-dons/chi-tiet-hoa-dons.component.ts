import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { ChiTietHoaDon, ChiTietHoaDonService } from './chi-tiet-hoa-don.service';
import { ChiTietHoaDonComponent } from './chi-tiet-hoa-don/chi-tiet-hoa-don.component';

@Component({
  selector: 'app-chi-tiet-hoa-dons',
  templateUrl: './chi-tiet-hoa-dons.component.html',
  styleUrls: ['./chi-tiet-hoa-dons.component.scss']
})
export class ChiTietHoaDonsComponent implements OnInit {
  @ViewChild(MatSort) sort: MatSort;
 
  @ViewChild(MatPaginator) paginator: MatPaginator;
  productList: any[];
  constructor(public service:ChiTietHoaDonService,
              public router : Router,
              public http: HttpClient,
              public dialog: MatDialog,) { }


              displayedColumns: string[] = ['id', 'soLuong','thanhTien','id_SanPhamBienThe','id_HoaDon','actions'];


  public chitiethoadon :  ChiTietHoaDon
  ngOnInit(): void {
    this.service.getAllChiTietHoaDons();
  }
  
  ngAfterViewInit(): void {
    this.service.dataSource.sort = this.sort;
    this.service.dataSource.paginator = this.paginator;
  }

  onModalDialog(){
    this.service.chitiethoadon = new ChiTietHoaDon()
    this.dialog.open(ChiTietHoaDonComponent)
  }


 doFilter = (value: string) => {
  this.service.dataSource.filter = value.trim().toLocaleLowerCase();
}

  populateForm(selectedRecord:ChiTietHoaDon){
    
    this.service.chitiethoadon = Object.assign({},selectedRecord)
    this.dialog.open(ChiTietHoaDonComponent)
}
  clickDelete(id){
  if(confirm('Bạn có chắc chắn xóa bản ghi này không ??'))
  {
    this.service.delete(id).subscribe(
      res=>{
        this.service.getAllChiTietHoaDons()
      }
    )
}
}
}
