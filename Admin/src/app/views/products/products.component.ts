import { Component, OnInit } from '@angular/core'
import {ProductService} from './product.service'
import * as signalR from '@microsoft/signalr';  
import {Product} from './product.model'
import {AfterViewInit,ViewChild} from '@angular/core';
import {MatSort} from '@angular/material/sort';
import {ImageProduct, ProductComponent} from './product/product.component'
import { map } from 'rxjs/operators';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import {MatDialog} from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ImagesmodelComponent } from './imagesmodel/imagesmodel.component';
import {MatAccordion} from '@angular/material/expansion';
@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit,AfterViewInit {

  public productcom : ProductComponent
  @ViewChild(MatSort) sort: MatSort;
 
  @ViewChild(MatPaginator) paginator: MatPaginator;
  imageproductList: any[];
  constructor(public service:ProductService,
              private breakpointObserver: BreakpointObserver, 
              public router : Router,
              public http: HttpClient,
              public dialog: MatDialog,) { }
public dataSource = new MatTableDataSource<Product>();

readonly url="https://localhost:44302/api/sanphams"
get(){
  return this.http.get(this.url)
}

delete(id:number){
  return this.http.delete(`${this.url}/${id}`)
}
getAllProducts(){
  return this.get().subscribe(res=>{
    this.dataSource.data = res as Product[];
    })
  }
  ngOnInit() {
    this.getAllProducts();
    const connection = new signalR.HubConnectionBuilder()  
    .configureLogging(signalR.LogLevel.Information)  
    .withUrl('https://localhost:44302/notify')  
    .build();  

  connection.start().then(function () {  
    console.log('SignalR Connected!');  
  }).catch(function (err) {  
    return console.error(err.toString());  
  });  

  connection.on("BroadcastMessage", () => {  
    this.getAllProducts(); 
  });  
  }
  populateImageProduct(selectedRecord:Product){
    this.service.product = Object.assign({},selectedRecord)
    this.http.get("https://localhost:44302/api/SanPhamBienThes/spbt/"+this.service.product.id).subscribe(
      res=>{
        this.imageproductList = res as ImageProduct[]
        console.log( this.imageproductList)
        this.onModal()
      },
      error=>{
      })
      
  }
  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }
  onModal(){
    this.dialog.open(ImagesmodelComponent)
  }
  public doFilter = (value: string) => {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }
  onSelectedAdd(){
    this.service.product = new Product();
    this.router.navigate(['product/add']);
  }
  onselectedDetail(){
    
    this.router.navigate(['product/detail/'+this.service.product.id]);
  }
  onSelectedEdit(){
    this.router.navigate(['product/edit/'+this.service.product.id]);
  }
  displayedColumns: string[] = ['id', 'ten','hinh',
    'gia',
    'khuyenMai',
   'trangThaiSanPham',
   'trangThaiSanPhamThietKe',
   'trangThaiHoatDong',
   'tenNhanHieu',
   'tenLoai',
   'actions'];
  product = new Product()
  prducts : Product[]
 
  detail(selectedRecord:Product){
    this.service.product = Object.assign({},selectedRecord)
    this.onselectedDetail()
  }
  populateForm(selectedRecord:Product){
    this.service.product = Object.assign({},selectedRecord)
    this.onSelectedEdit();
  }
  clickDelete(id){
  if(confirm('Bạn có chắc chắn xóa bản ghi này không ??'))
  {
    this.service.delete(id).subscribe(
      res=>{
        this.getAllProducts()
        }
      )
    }
  }

  
}