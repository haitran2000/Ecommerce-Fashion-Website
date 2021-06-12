import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { FileToUploadService } from '../../shared/file-to-upload.service';
import { ToastServiceService } from '../../shared/toast-service.service';
import { Item, ItemService } from './item.service';
import { ItemComponent } from './item/item.component';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.scss']
})
export class ItemsComponent implements OnInit {
  @ViewChild(MatSort) sort: MatSort;
 
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(public service:ItemService,
    public router : Router,
    public http: HttpClient,
    public dialog: MatDialog,
    public serviceToast : ToastServiceService,
   ) { }

displayedColumns: string[] = ['id', 'trangThai','hinh',
'actions'];


public item :  Item
ngOnInit(): void {
this.service.getAllItems();
}

ngAfterViewInit(): void {
this.service.dataSource.sort = this.sort;
this.service.dataSource.paginator = this.paginator;
}

onModalDialog(){
this.service.item = new Item()
this.dialog.open(ItemComponent)
}

doFilter = (value: string) => {
this.service.dataSource.filter = value.trim().toLocaleLowerCase();
}

populateForm(selectedRecord:Item){
this.service.item = Object.assign({},selectedRecord)
this.dialog.open(ItemComponent)
}
clickDelete(id){
if(confirm('Bạn có chắc chắn xóa bản ghi này không ??'))
{
this.service.delete(id).subscribe(
res=>{
  this.serviceToast.showToastXoaThanhCong()
this.service.getAllItems()
},err=>{
  this.serviceToast.showToastXoaThatBai()
}
)
}
}}
