
import { HttpClient } from "@angular/common/http";
import { Injectable, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";
import { MauSac } from "./mau-sacs.component";
@Injectable({
    providedIn: 'root'
  })
export class MauSacService{
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<MauSac>();
    mausac:MauSac = new MauSac()
    readonly url="https://localhost:44302/api/mausacs"
    constructor(public http:HttpClient) { }
    get(){
      return this.http.get(this.url)
    }
    delete(id:number){
      return this.http.delete(`${this.url}/${id}`)
    }
    getAllMauSacs(){
      this.http.get("https://localhost:44302/api/mausacs").subscribe(
        res=>{
          this.dataSource.data = res as MauSac[];
        }
      )
    }
  }
