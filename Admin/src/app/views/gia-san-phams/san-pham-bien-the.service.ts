import { HttpClient } from "@angular/common/http";
import { Injectable, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";
import { SanPhamBienThe, SanPhamBienThesComponent } from "./san-pham-bien-thes.component";
@Injectable({
    providedIn: 'root'
  })
export class SanPhamBienTheService{
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<SanPhamBienThe>();
    sanphambienthe:SanPhamBienThe = new SanPhamBienThe()
    readonly url="https://localhost:44302/api/sanphambienthes"
    constructor(public http:HttpClient) { }
    get(){
      return this.http.get(this.url)
    }
    delete(id:number){
      return this.http.delete(`${this.url}/${id}`)
    }
    getAllSanPhamBienThes(){
      this.http.get("https://localhost:44302/api/sanphambienthes").subscribe(
        res=>{
          this.dataSource.data = res as SanPhamBienThe[];
        }
      )
    }
  }