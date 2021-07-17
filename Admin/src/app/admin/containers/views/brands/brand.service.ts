
import { HttpClient } from "@angular/common/http";
import { Injectable, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";
import { environment } from "../../../../../environments/environment";

@Injectable({
    providedIn: 'root'
  })
export class BrandService{
  @ViewChild(MatSort) sort: MatSort;  
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<Brand>();
    brand:Brand = new Brand()
    readonly url=environment.URL_API+"nhanhieus"
    constructor(public http:HttpClient) { }
    get(){
      return this.http.get(this.url)
    }
    delete(id:number){
      return this.http.delete(`${this.url}/${id}`)
    }
    getAllBrands(){
      this.http.get(environment.URL_API+"nhanhieus").subscribe(
        res=>{
          this.dataSource.data = res as Brand[];
        }
      )
    }
  }
  export class Brand{
    id : number = 0
    ten : string
    thongTin : string 
    imagePath : string 
  }
  