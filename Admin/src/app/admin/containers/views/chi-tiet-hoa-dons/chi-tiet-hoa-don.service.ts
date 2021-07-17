import { HttpClient } from "@angular/common/http";
import { Injectable, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";
import { environment } from "../../../../../environments/environment";



@Injectable({
    providedIn: 'root'
  })
export class ChiTietHoaDonService{
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<ChiTietHoaDon>();
    chitiethoadon:ChiTietHoaDon = new ChiTietHoaDon()
    readonly url=environment.URL_API+"chitiethoadons"
    constructor(public http:HttpClient) { }
    get(){
      return this.http.get(this.url)
    }
    delete(id:number){
      return this.http.delete(`${this.url}/${id}`)
    }
    getAllChiTietHoaDons(){
      this.http.get(environment.URL_API+"chitiethoadons").subscribe(
        res=>{
          this.dataSource.data = res as ChiTietHoaDon[];
        }
      )
    }
  }
  export class ChiTietHoaDon{
    id: number
    soLuong: number
    thanhTien:number
    id_SanPhamBienThe: number
    id_HoaDon :number
  }