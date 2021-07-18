import { HttpClient } from "@angular/common/http";
import { Injectable, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";
import { environment } from "../../../../../environments/environment";
import { SanPhamBienThe, SanPhamBienThesComponent, SanPhamBienTheSS } from "./san-pham-bien-thes.component";
@Injectable({
    providedIn: 'root'
  })
export class SanPhamBienTheService{
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<SanPhamBienTheSS>();
    sanphambienthe:SanPhamBienThe = new SanPhamBienThe()
    spbts: SanPhamBienThe[]
    tensizeloai:any
    readonly url=environment.URL_API+"sanphambienthes"
    constructor(public http:HttpClient) { }
    get(){
      return this.http.get(this.url)
    }
    delete(id:number){
      return this.http.delete(`${this.url}/${id}`)
    }
    getAllSanPhamBienThes(){
      this.http.get(environment.URL_API+"sanphambienthes/sanphambienthe").subscribe(
        res=>{
          this.dataSource.data = res as SanPhamBienTheSS[];
        }
      )
    }
    getAllSanPhams(){
      return this.http.get(environment.URL_API+"sanphams/sp")
    }
    getAllTenSizeLoai(){
      return this.http.get(environment.URL_API+"sizes/tensizeloai")
    }
    getAllTenMauLoai(){
      return this.http.get(environment.URL_API+"mausacs/tenmauloai")
    }
  }

  export class LoaiMau{
    loaiTenMau: string
  }