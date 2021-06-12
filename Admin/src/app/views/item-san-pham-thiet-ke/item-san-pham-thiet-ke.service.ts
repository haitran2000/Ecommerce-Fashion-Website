import { HttpClient } from '@angular/common/http';
import { Injectable, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Injectable({
  providedIn: 'root'
})
export class ItemSanPhamThietKeService {
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<ItemSanPhamThietKe>();
  itemsp = new ItemSanPhamThietKe
  
  constructor(public http:HttpClient) { }
  private url = "https://localhost:5001/api/item_sanphamthietke";
  get(){
    this.http.get(this.url).subscribe(
      res=>{
        this.dataSource.data = res as ItemSanPhamThietKe[]
      }
    )
  }
}
export class ItemSanPhamThietKe{
  itemId: number
  sanPhamThietKeId : number
}