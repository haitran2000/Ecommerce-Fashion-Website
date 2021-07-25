import { HttpClient } from "@angular/common/http";
import { Injectable, ViewChild } from "@angular/core";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";
import { environment } from "../../../../../environments/environment";
import { CTHDViewModel, HoaDon } from "./hoa-dons.component";

@Injectable({
  providedIn: 'root'
})
export class HoaDonService {
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  public dataSource = new MatTableDataSource<HoaDon>();
  public dataSource2 = new MatTableDataSource<CTHDViewModel>();
  public dataOneBill: any[]
  hoadon: HoaDon = new HoaDon()
  cthdViewModel: CTHDViewModel = new CTHDViewModel()
  readonly url = environment.URL_API + "hoadons"
  constructor(public http: HttpClient) { }
  get() {
    return this.http.get(this.url)
  }
  delete(id: number) {
    return this.http.delete(`${this.url}/${id}`)
  }
  getHoaDon(id: number) {
    this.http.get(environment.URL_API + "hoadons/" + id).subscribe(
      res => {
        this.dataSource2.data = res as CTHDViewModel[];
        this.dataOneBill = res as CTHDViewModel[]
      }
    )
  }
  getAllHoaDons() {
    this.http.get(environment.URL_API + "hoadons").subscribe(
      res => {
        this.dataSource.data = res as HoaDon[];

      }
    )
  }
}