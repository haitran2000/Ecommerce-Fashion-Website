import { HttpClient } from "@angular/common/http";
import { Injectable, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";
import { GiaSanPham, GiaSanPhamsComponent } from "./gia-san-phams.component";
@Injectable({
    providedIn: 'root'
  })
export class GiaSanPhamService{
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<GiaSanPham>();
    giasanpham:GiaSanPham = new GiaSanPham()
    readonly url="https://localhost:44302/api/giasanphams"
    constructor(public http:HttpClient) { }
    get(){
      return this.http.get(this.url)
    }
    delete(id:number){
      return this.http.delete(`${this.url}/${id}`)
    }
    getAllGiaSanPhams(){
      this.http.get("https://localhost:44302/api/giasanphams").subscribe(
        res=>{
          this.dataSource.data = res as GiaSanPham[];
        }
      )
    }
  }