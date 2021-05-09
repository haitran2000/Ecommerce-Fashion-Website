import { HttpClient } from "@angular/common/http";
import { Injectable, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";
import { Category } from "./categories.component";
@Injectable({
    providedIn: 'root'
  })
export class CategoryService{
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<Category>();
    category:Category = new Category()
    readonly url="https://localhost:44302/api/loais"
    constructor(public http:HttpClient) { }
    get(){
      return this.http.get(this.url)
    }
    delete(id:number){
      return this.http.delete(`${this.url}/${id}`)
    }
    getAllCategories(){
      this.http.get("https://localhost:44302/api/loais").subscribe(
        res=>{
          this.dataSource.data = res as Category[];
        }
      )
    }
  }
