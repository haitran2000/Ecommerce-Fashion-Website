import { HttpClient } from '@angular/common/http';
import { AfterViewInit, ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { MauSacService } from './mau-sac.service';
import { MauSacComponent } from './mau-sac/mau-sac.component';

@Component({
  selector: 'app-mau-sacs',
  templateUrl: './mau-sacs.component.html',
  styleUrls: ['./mau-sacs.component.scss']
})
export class MauSacsComponent implements OnInit, AfterViewInit {

  
  @ViewChild(MatSort) sort: MatSort;
 
  @ViewChild(MatPaginator) paginator: MatPaginator;
  productList: any[];
  constructor(public service:MauSacService,
              public router : Router,
              public http: HttpClient,
              public dialog: MatDialog,) { }
public dataSource = new MatTableDataSource<MauSac>();
displayedColumns: string[] = ['id', 'maMau','tenLoai',
  'actions'];



  ngOnInit(): void {
    this.service.getAllMauSacs();
  }
  
  ngAfterViewInit(): void {
    this.service.dataSource.sort = this.sort;
    this.service.dataSource.paginator = this.paginator;
  }

  onModalDialog(){
    this.service.mausac = new MauSac()
    this.dialog.open(MauSacComponent)
  }

 doFilter = (value: string) => {
  this.service.dataSource.filter = value.trim().toLocaleLowerCase();
}

  populateForm(selectedRecord:MauSac){
    this.service.mausac = Object.assign({},selectedRecord)
    this.dialog.open(MauSacComponent)
}
  clickDelete(id){
  if(confirm('Bạn có chắc chắn xóa bản ghi này không ??'))
  {
    this.service.delete(id).subscribe(
      res=>{
        this.service.getAllMauSacs()
      }
    )
}
}}
export class MauSac{
  id: number = 0
  maMau : string
  id_Loai : number
}