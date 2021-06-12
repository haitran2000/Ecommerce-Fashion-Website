
import { HttpClient } from "@angular/common/http";
import { Injectable, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";

@Injectable({
    providedIn: 'root'
  })
export class BrandService{
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<Brand>();
    brand:Brand = new Brand()
    readonly url="https://localhost:5001/api/nhanhieus"
    constructor(public http:HttpClient) { }
    get(){
      return this.http.get(this.url)
    }
    delete(id:number){
      return this.http.delete(`${this.url}/${id}`)
    }
    getAllBrands(){
      this.http.get("https://localhost:5001/api/nhanhieus").subscribe(
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
  