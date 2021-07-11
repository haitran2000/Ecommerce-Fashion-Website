import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { ItemSanPhamThietKeService } from './item-san-pham-thiet-ke.service';

@Component({
  selector: 'app-item-san-pham-thiet-ke',
  templateUrl: './item-san-pham-thiet-ke.component.html',
  styleUrls: ['./item-san-pham-thiet-ke.component.scss']
})
export class ItemSanPhamThietKeComponent implements OnInit,AfterViewInit {
  @ViewChild(MatSort) sort: MatSort;
  displayedColumns: string[] = ['itemId', 'sanPhamThietKeId',];

 
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(public service: ItemSanPhamThietKeService) { }

  ngOnInit(): void {
    this.service.get()
  }
  ngAfterViewInit(): void {
    this.service.dataSource.sort = this.sort;
    this.service.dataSource.paginator = this.paginator;
    }
    doFilter = (value: string) => {
      this.service.dataSource.filter = value.trim().toLocaleLowerCase();
      }
}
