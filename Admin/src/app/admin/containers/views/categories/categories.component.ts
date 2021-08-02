import { HttpClient } from '@angular/common/http';
import { AfterViewInit, ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ToastServiceService } from '../../shared/toast-service.service';
import { Category, CategoryService } from './category.service';
import { CategoryComponent } from './category/category.component';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss']
})
export class CategoriesComponent implements OnInit, AfterViewInit {

  
  @ViewChild(MatSort) sort: MatSort;
 
  @ViewChild(MatPaginator) paginator: MatPaginator;
  productList: any[];
  constructor(public service:CategoryService,
              public router : Router,
              public http: HttpClient,
              public dialog: MatDialog,
              public toastService: ToastServiceService) { }

displayedColumns: string[] = ['id', 'ten','namNu',
  'actions'];


  public category :  Category
  ngOnInit(): void {
    this.service.getAllCategories();
  }
  
  ngAfterViewInit(): void {
    this.service.dataSource.sort = this.sort;
    this.service.dataSource.paginator = this.paginator;
  }

  onModalDialog(){
    this.service.category = new Category()
    this.dialog.open(CategoryComponent)
  }

 doFilter = (value: string) => {
  this.service.dataSource.filter = value.trim().toLocaleLowerCase();
}

  populateForm(selectedRecord:Category){
    this.service.category = Object.assign({},selectedRecord)
    this.dialog.open(CategoryComponent)
}
  clickDelete(id){
  if(confirm('Bạn có chắc chắn xóa bản ghi này không ??'))
  {
    this.service.delete(id).subscribe(
      res=>{
        this.toastService.showToastXoaThanhCong()
        this.service.getAllCategories()
      },
      err=>{
        this.toastService.showToastXoaThanhCong()
      }
    )
}
}}
