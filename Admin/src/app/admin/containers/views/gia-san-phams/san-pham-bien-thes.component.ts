import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { ToastServiceService } from '../../shared/toast-service.service';
import { SanPhamBienTheService } from './san-pham-bien-the.service';
import { SanPhamBienTheComponent } from './san-pham-bien-the/san-pham-bien-thecomponent';

@Component({
  selector: 'app-san-pham-bien-thes',
  templateUrl: './san-pham-bien-thes.component.html',
  styleUrls: ['./san-pham-bien-thes.component.scss']
})
export class SanPhamBienThesComponent implements OnInit, AfterViewInit {

  @ViewChild(MatSort) sort: MatSort;
 
  @ViewChild(MatPaginator) paginator: MatPaginator;
  productList: any[];
  constructor(public service:SanPhamBienTheService,
              public router : Router,
              public http: HttpClient,
              public dialog: MatDialog,
              public serviceToast : ToastServiceService,) { }


              displayedColumns: string[] = ['id','maMau','tenSanPham','tenSize',
  'actions'];


  public sanphambienthe :  SanPhamBienThe
  ngOnInit(): void {
    this.service.getAllSanPhamBienThes();
  }
  onSelectedSPTK(a: SanPhamBienThe):void{
    this.service.sanphambienthe = a
  }
  ngAfterViewInit(): void {
    this.service.dataSource.sort = this.sort;
    this.service.dataSource.paginator = this.paginator;
  }

  onModalDialog(){
    this.service.sanphambienthe = new SanPhamBienThe()
    this.dialog.open(SanPhamBienTheComponent)
  }

 doFilter = (value: string) => {
  this.service.dataSource.filter = value.trim().toLocaleLowerCase();
}

  populateForm(selectedRecord:SanPhamBienThe){
    
    this.service.sanphambienthe = Object.assign({},selectedRecord)
    this.dialog.open(SanPhamBienTheComponent)
}
  clickDelete(id){
  if(confirm('Bạn có chắc chắn xóa bản ghi này không ??'))
  {
    this.service.delete(id).subscribe(
      res=>{
        this.serviceToast.showToastXoaThanhCong()
        this.service.getAllSanPhamBienThes()
      },
      err=>{
        this.serviceToast.showToastXoaThatBai()
      }
    )
}
}}
export class SanPhamBienThe{
  id : number = 0
  mauId : number 
  sanPhamId : number
  sizeId : number
}