import { HttpClient } from "@angular/common/http";
import { Injectable, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";



@Injectable({
    providedIn: 'root'
  })
export class ChiTietHoaDonService{
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<ChiTietHoaDon>();
    chitiethoadon:ChiTietHoaDon = new ChiTietHoaDon()
    readonly url="https://localhost:5001/api/chitiethoadons"
    constructor(public http:HttpClient) { }
    get(){
      return this.http.get(this.url)
    }
    delete(id:number){
      return this.http.delete(`${this.url}/${id}`)
    }
    getAllChiTietHoaDons(){
      this.http.get("https://localhost:5001/api/chitiethoadons").subscribe(
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