
import { HttpClient } from "@angular/common/http";
import { Injectable, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";
import { environment } from "../../../../../environments/environment";

@Injectable({
    providedIn: 'root'
  })
export class MauSacService{
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<MauSac>();
    mausac:MauSac = new MauSac()
    tensizeloai: any
   
    constructor(public http:HttpClient) { }

    delete(id:number){
      return this.http.delete(`${environment.URL_API+"mausacs"}/${id}`)
    }

    /* Dùng cho component Product sau khi thêm hoặc sửa xong */
    getAllMauSacs(){
      this.http.get(environment.URL_API+"mausacs").subscribe(
        res=>{
          this.dataSource.data = res as MauSac[];
        }
      )
    }
    getAllMauSacLoais(){
      return this.http.get(environment.URL_API+"sizes/tensizeloai")
    }
  }
  export class MauSac{
    id: number = 0
    maMau : string
    id_Loai : number
  }
  
  export class User{
    id : string
    ImagePath:string
    imagePath: string
    userName:string
    lastName:string
    firstName:string
    quyen:string
  }

  export class MauSacLoai{

  }