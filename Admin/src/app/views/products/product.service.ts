import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import {MatTableDataSource} from '@angular/material/table';

import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  
  paginator: MatPaginator | undefined;
  sort: MatSort | undefined;
  constructor( public http : HttpClient) { }
    listData : MatTableDataSource<any>;
    product: Product = new Product();
    readonly url="https://localhost:5001/api/sanphams"
    get(){
      return this.http.get(this.url)
    }
    
    delete(id:number){
      return this.http.delete(`${this.url}/${id}`)
    }
    getAllProducts(){
      return this.get().subscribe(res=>{
        let Array = res as Product[]
        this.listData = new MatTableDataSource(Array)
        })
    }
      private getSortedData(data: Product[]): Product[] {
        if (!this.sort || !this.sort.active || this.sort.direction === '') {
          return data;
        }
    
        return data.sort((a, b) => {
          const isAsc = this.sort?.direction === 'asc';
          switch (this.sort?.active) {
            case 'name': return compare(a.ten, b.ten, isAsc);
            case 'id': return compare(+a.id, +b.id, isAsc);
            default: return 0;
          }
        });
      }
    }
    
    /** Simple sort comparator for example ID/Name columns (for client-side sorting). */
    function compare(a: string | number, b: string | number, isAsc: boolean): number {
      return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
    }   

    export class Product {
      id:number=0
      ten:string
      khuyenMai:number
      moTa:string
      khoiLuong:number
      gia:number
      tag:string
      huongDan:string
      thanhPhan:string
      trangThaiSanPham:string
      trangThaiHoatDong:string
      trangThaiSanPhamThietKe:string
      id_NhanHieu : number
      id_Loai: number
      giaSanPhams : number
      sanPhamThietKes  : number
      sanPham_SanPhamThietKe : number 
      tenNhanHieu : string
      tenLoai : string
  }
  