
import { HttpClient } from "@angular/common/http";
import { Injectable, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";
import { environment } from "../../../../../environments/environment";
import { Size } from "./sizes.component";

@Injectable({
    providedIn: 'root'
  })
export class SizeService{
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<Size>();
    size:Size = new Size()
    readonly url=environment.URL_API+"sizes"
    constructor(public http:HttpClient) { }
    get(){
      return this.http.get(this.url)
    }
    delete(id:number){
      return this.http.delete(`${this.url}/${id}`)
    }
    getAllSizes(){
      this.http.get(environment.URL_API+"sizes").subscribe(
        res=>{
          this.dataSource.data = res as Size[];
        }
      )
    }
  }
