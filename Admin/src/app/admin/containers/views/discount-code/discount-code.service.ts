import { HttpClient } from '@angular/common/http';
import { Injectable, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { environment } from '../../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DiscountCodeService {
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(private http:HttpClient) { }
  public dataSource = new MatTableDataSource<MaGiamGia>();
  get():Observable<any>{
    return this.http.get(environment.URL_API+"MaGiamGias")
  }
  getAllMaGiamGias(){
    this.get().subscribe(
    result=>{ 
      this.dataSource.data = result as MaGiamGia[];
    },
    error=>{

    })
  }
}
export class MaGiamGia{
  id:number=0
  code:string
  soTienGiam:number
}
