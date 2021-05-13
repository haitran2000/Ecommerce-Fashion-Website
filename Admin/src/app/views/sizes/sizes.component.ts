import { HttpClient } from '@angular/common/http';
import { AfterViewInit, ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { SizeService } from './size.service';
import { SizeComponent } from './size/size.component';

@Component({
  selector: 'app-sizes',
  templateUrl: './sizes.component.html',
  styleUrls: ['./sizes.component.scss']
})
export class SizesComponent implements OnInit, AfterViewInit {

  
  @ViewChild(MatSort) sort: MatSort;
 
  @ViewChild(MatPaginator) paginator: MatPaginator;
  productList: any[];
  constructor(public service:SizeService,
              public router : Router,
              public http: HttpClient,
              public dialog: MatDialog,) { }
public dataSource = new MatTableDataSource<Size>();
displayedColumns: string[] = ['id', 'size1','tenLoai',
  'actions'];


  public size :  Size
  ngOnInit(): void {
    this.service.getAllSizes();
  }
  
  ngAfterViewInit(): void {
    this.service.dataSource.sort = this.sort;
    this.service.dataSource.paginator = this.paginator;
  }

  onModalDialog(){
    this.service.size.id ==0
    this.dialog.open(SizeComponent)
    
  }

 doFilter = (value: string) => {
  this.service.dataSource.filter = value.trim().toLocaleLowerCase();
}

  populateForm(selectedRecord:Size){
    this.service.size = Object.assign({},selectedRecord)
    this.dialog.open(SizeComponent)
}
  clickDelete(id){
  if(confirm('Bạn có chắc chắn xóa bản ghi này không ??'))
  {
    this.service.delete(id).subscribe(
      res=>{
        this.service.getAllSizes()
      }
    )
}
}}
export class Size{
  id : number = 0
  size1 : string
  loaiId : string 
}
