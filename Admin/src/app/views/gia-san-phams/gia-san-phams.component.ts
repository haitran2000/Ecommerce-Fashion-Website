import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { GiaSanPhamService } from './gia-san-pham.service';
import { GiaSanPhamComponent } from './gia-san-pham/gia-san-pham.component';

@Component({
  selector: 'app-gia-san-phams',
  templateUrl: './gia-san-phams.component.html',
  styleUrls: ['./gia-san-phams.component.scss']
})
export class GiaSanPhamsComponent implements OnInit, AfterViewInit {

  @ViewChild(MatSort) sort: MatSort;
 
  @ViewChild(MatPaginator) paginator: MatPaginator;
  productList: any[];
  constructor(public service:GiaSanPhamService,
              public router : Router,
              public http: HttpClient,
              public dialog: MatDialog,) { }


              displayedColumns: string[] = ['id', 'gia','maMau','tenSanPham','size1',
  'actions'];


  public giasanpham :  GiaSanPham
  ngOnInit(): void {
    this.service.getAllGiaSanPhams();
  }
  
  ngAfterViewInit(): void {
    this.service.dataSource.sort = this.sort;
    this.service.dataSource.paginator = this.paginator;
  }

  onModalDialog(){
    this.service.giasanpham.id==0
    this.dialog.open(GiaSanPhamComponent)
  }

 doFilter = (value: string) => {
  this.service.dataSource.filter = value.trim().toLocaleLowerCase();
}

  populateForm(selectedRecord:GiaSanPham){
    
    this.service.giasanpham = Object.assign({},selectedRecord)
    this.dialog.open(GiaSanPhamComponent)
}
  clickDelete(id){
  if(confirm('Bạn có chắc chắn xóa bản ghi này không ??'))
  {
    this.service.delete(id).subscribe(
      res=>{
        this.service.getAllGiaSanPhams()
      }
    )
}
}}
export class GiaSanPham{
  id : number = 0
  gia : string
  mauId : number 
  sanPhamId : number
  sizeId : number
}