import { HttpClient } from '@angular/common/http';
import { AfterViewInit, ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Brand, BrandService } from './brand.service';
import { BrandComponent } from './brand/brand.component';
import { NotifierService } from 'angular-notifier';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-brands',
  templateUrl: './brands.component.html',
  styleUrls: ['./brands.component.scss']
})
export class BrandsComponent implements OnInit, AfterViewInit {

  private readonly notifier: NotifierService;
  @ViewChild(MatSort) sort: MatSort;
 
  @ViewChild(MatPaginator) paginator: MatPaginator;
  productList: any[];
  constructor(public service:BrandService,
              public router : Router,
              public http: HttpClient,
              public dialog: MatDialog,
              public toastr: ToastrService,
              notifierService: NotifierService) {  this.notifier = notifierService; }

displayedColumns: string[] = ['id', 'ten','hinh','thongTin',
  'actions'];


  public brand :  Brand
  ngOnInit(): void {
    this.service.getAllBrands();


  }
  
  ngAfterViewInit(): void {
    this.service.dataSource.sort = this.sort;
    this.service.dataSource.paginator = this.paginator;
  }

  onModalDialog(){
 
    this.service.brand = new Brand()
  
    this.dialog.open(BrandComponent)
  }

 doFilter = (value: string) => {
  this.service.dataSource.filter = value.trim().toLocaleLowerCase();
}
showToastXoaThanhCong(){
  this.toastr.success("Xóa thành công")
}
showToastXoaThatBai(){
  this.toastr.error("Xóa thất bại")
}
  populateForm(selectedRecord:Brand){
    this.service.brand = Object.assign({},selectedRecord)
    this.dialog.open(BrandComponent)
}
  clickDelete(id){
  if(confirm('Bạn có chắc chắn xóa bản ghi này không ??'))
  {
    this.service.delete(id).subscribe(
      res=>{
        this.service.getAllBrands()
        this.showToastXoaThanhCong()
      }
      ,err=>{
        this.showToastXoaThatBai()
      }
    )
}
}}
