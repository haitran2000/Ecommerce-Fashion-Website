import { Component, OnInit } from '@angular/core'
import {ProductService} from './product.service'

import {Product} from './product.model'
import {AfterViewInit,ViewChild} from '@angular/core';
import {MatSort} from '@angular/material/sort';
import {ProductComponent} from './product/product.component'
import { map } from 'rxjs/operators';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import {MatDialog} from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {


  paginator: MatPaginator | undefined;
  sort: MatSort | undefined;

  constructor(public service:ProductService,
              private breakpointObserver: BreakpointObserver, 
              public dialog: MatDialog,
              public router : Router) { }

  ngOnInit(): void {
    this.service.getAllProducts()
  }
  onSelected(){
    this.router.navigate(['product']);
}
  displayedColumns: string[] = ['id', 'ten', 'imagePath',
   'trangThaiSanPham',
   'brandId','categoryId',
  'actions'];
  product = new Product()
  prducts : Product[]
 
  populateForm(selectedRecord:Product){
    this.service.product = Object.assign({},selectedRecord)
    this.onSelected();
  }
  clickDelete(id){
  if(confirm('Bạn có chắc chắn xóa bản ghi này không ??'))
  {
    this.service.delete(id).subscribe(
      res=>{
        this.service.getAllProducts()
        }
      )
    }
  }
}