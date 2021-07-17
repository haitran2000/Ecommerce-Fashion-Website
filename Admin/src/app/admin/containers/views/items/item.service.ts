import { HttpClient } from '@angular/common/http';
import { Injectable, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { environment } from '../../../../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ItemService {
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<Item>();
  item : Item = new Item()
  public items : Item[]
  readonly url=environment.URL_API+"items"
  constructor(public http:HttpClient) { }
  get(){
    return this.http.get(this.url)
  }
  delete(id:number){
    return this.http.delete(`${this.url}/${id}`)
  }
  getAllItems(){
    this.http.get(environment.URL_API+"items").subscribe(
      res=>{
        this.dataSource.data = res as Item[];
      }
    )
  }
  getAllItemss(){
    this.http.get(environment.URL_API+"items").subscribe(
      res=>{
        this.items = res as Item[];
      }
    )
  }
}

export class Item{
  id : number = 0
  hinhAnh : string
  trangThai : string
 }