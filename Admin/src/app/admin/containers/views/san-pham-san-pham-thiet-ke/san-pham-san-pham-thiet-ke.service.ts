
import { HttpClient } from "@angular/common/http";
import { Injectable, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";
import { environment } from "../../../../../environments/environment";

@Injectable({
    providedIn: 'root'
  })
export class SanPhamSanPhamThietKeService{
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<SanPhamSanPhamThietKe>();
    size:SanPhamSanPhamThietKe = new SanPhamSanPhamThietKe()
    readonly url=environment.URL_API+"sanpham_sanphamthietke"
    constructor(public http:HttpClient) { }
   
    delete(id:number){
      return this.http.delete(`${this.url}/${id}`)
    }
    getAllSanPhamSanPhamThietKes(){
    
      return this.http.get(this.url).subscribe(
        res=>{
          this.dataSource.data = res as SanPhamSanPhamThietKe[];
        }
      )
    }
  }
  export class SanPhamSanPhamThietKe{
    sanPhamId:number
    sanPhamThietKeId:number
  }