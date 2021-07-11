
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";
import { DomSanitizer, SafeHtml } from "@angular/platform-browser";
import { BehaviorSubject } from "rxjs";
import { GetSPTK } from "./san-pham-thiet-kes.component";
;
@Injectable({
    providedIn: 'root'
  })
export class SanPhamThietKeService{
  newSteps=[];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<sptk>();
  
  public data : GetSPTK[]
  public datasptk : sptk[]

   sanphamthietke:GetSPTK = new GetSPTK()
    readonly url="https://cozastores.azurewebsites.net/api/SanPhamThietKes"
    constructor(public http:HttpClient, private sanitizer: DomSanitizer) { }
    get(){
      return this.http.get(this.url)
    }
    delete(id:number){
      return this.http.delete(`${this.url}/${id}`)
    }
    
    private messageSource = new BehaviorSubject('Default message');
    currentMessage = this.messageSource.asObservable();
    changeMessage(message: string) {
      this.messageSource.next(message);
    }
    getAllSanPhamThietKes(){
      this.http.get("https://cozastores.azurewebsites.net/api/GetSanPhamThuongDeThietKes" ,{ headers: new HttpHeaders({"Access-Control-Allow-Origin":"*"})
    }).subscribe(
        res=>{
          this.data = res as GetSPTK[];
        }
      )
    }

    getsptk(){
      this.http.get("https://cozastores.azurewebsites.net/api/SanPhamThietKes").subscribe(
        res=>{
          this.dataSource.data = res as sptk[];
          this.datasptk = res as sptk[];
        
       
        }
      )
    }
  }

  export class sptk{
    id: number
    hinhAnh: string
  }
  export class sptk2{
    id: number
    hinhAnh: SafeHtml
  }