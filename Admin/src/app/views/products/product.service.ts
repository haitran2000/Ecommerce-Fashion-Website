import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import {MatTableDataSource} from '@angular/material/table';
import { Product } from './product.model';
@Injectable({
  providedIn: 'root'
})
export class ProductService {
  constructor( public http : HttpClient) { }
    listData : MatTableDataSource<any>;
    product: Product = new Product();
    readonly url="https://localhost:44302/api/sanphams"
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
}
