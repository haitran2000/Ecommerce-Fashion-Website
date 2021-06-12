import { HttpClient } from "@angular/common/http";
import { Injectable, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";

@Injectable({
    providedIn: 'root'
  })
export class CategoryService{
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<Category>();
    category:Category = new Category()
    readonly url="https://localhost:5001/api/loais"
    constructor(public http:HttpClient) { }
    get(){
      return this.http.get(this.url)
    }
    delete(id:number){
      return this.http.delete(`${this.url}/${id}`)
    }
    getAllCategories(){
      this.http.get("https://localhost:5001/api/loais").subscribe(
        res=>{
          this.dataSource.data = res as Category[];
        }
      )
    }
  }
  export class Category{
    id : number = 0
    ten : string
    imagePath : string 
  }
  