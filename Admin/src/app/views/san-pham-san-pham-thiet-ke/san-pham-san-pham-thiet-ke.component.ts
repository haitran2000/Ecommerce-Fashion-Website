import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { SanPhamBienThe } from '../gia-san-phams/san-pham-bien-thes.component';
import { ItemSanPhamThietKeService } from '../item-san-pham-thiet-ke/item-san-pham-thiet-ke.service';
import { ItemService } from '../items/item.service';
import { SanPhamSanPhamThietKe, SanPhamSanPhamThietKeService } from './san-pham-san-pham-thiet-ke.service';

@Component({
  selector: 'app-san-pham-san-pham-thiet-ke',
  templateUrl: './san-pham-san-pham-thiet-ke.component.html',
  styleUrls: ['./san-pham-san-pham-thiet-ke.component.scss']
})
export class SanPhamSanPhamThietKeComponent implements OnInit {

  @Input() sanphambienthe = SanPhamBienThe 
  @ViewChild(MatSort) sort: MatSort;
 
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(public service:SanPhamSanPhamThietKeService,
    public router : Router,
    public http: HttpClient,
    public dialog: MatDialog,) { }

displayedColumns: string[] = ['sanPhamId', 'sanPhamThietKeId'];


public spsptk :  SanPhamSanPhamThietKe
ngOnInit(): void {
this.service.getAllSanPhamSanPhamThietKes();
}

ngAfterViewInit(): void {
this.service.dataSource.sort = this.sort;
this.service.dataSource.paginator = this.paginator;
}



doFilter = (value: string) => {
this.service.dataSource.filter = value.trim().toLocaleLowerCase();
}


}
