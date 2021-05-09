
import { HttpClient } from "@angular/common/http";
import { Injectable, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";
import { Brand} from "./brands.component";
@Injectable({
    providedIn: 'root'
  })
export class BrandService{
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<Brand>();
    category:Brand = new Brand()
    readonly url="https://localhost:44302/api/thuonghieus"
    constructor(public http:HttpClient) { }
    get(){
      return this.http.get(this.url)
    }
    delete(id:number){
      return this.http.delete(`${this.url}/${id}`)
    }
    getAllBrands(){
      this.http.get("https://localhost:44302/api/thuonghieus").subscribe(
        res=>{
          this.dataSource.data = res as Brand[];
        }
      )
    }
  }
