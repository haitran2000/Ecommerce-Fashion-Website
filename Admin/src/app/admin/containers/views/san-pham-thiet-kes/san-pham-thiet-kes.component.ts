import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { SanPhamThietKeService, sptk } from './san-pham-thiet-ke.service';
import { DomSanitizer} from '@angular/platform-browser';
import { NotifierService } from 'angular-notifier';
import { ToastServiceService } from '../../shared/toast-service.service';

@Component({
  selector: 'app-san-pham-thiet-kes',
  templateUrl: './san-pham-thiet-kes.component.html',
  styleUrls: ['./san-pham-thiet-kes.component.scss']
})
export class SanPhamThietKesComponent implements OnInit {

  private readonly notifier: NotifierService;

  @ViewChild(MatSort) sort: MatSort;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  productList: any[];
  constructor(public toastService : ToastServiceService,
              public service:SanPhamThietKeService,
              public router : Router,
              public http: HttpClient,
              private sanitizer: DomSanitizer,
              notifierService: NotifierService,
                                                ){
                                                  this.notifier = notifierService;
                                                 }

  a = [];

displayedColumns: string[] = ['id','hinh',
  'actions'];

  steps = [ { 
    "icon": `<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" version=\"1.1\" width=\"500\" height=\"800\" viewBox=\"0 0 500 800\" xml:space=\"preserve\">\n<desc>Created with Fabric.js 4.5.0</desc>\n<defs>\n</defs>\n<g transform=\"matrix(0.27 0 0 0.27 112.25 169.51)\"  >\n\t<image style=\"stroke: none; stroke-width: 0; stroke-dasharray: none; stroke-linecap: butt; stroke-dashoffset: 0; stroke-linejoin: miter; stroke-miterlimit: 4; fill: rgb(0,0,0); fill-rule: nonzero; opacity: 1;\"  xlink:href=\"https://localhost:44302/Images/san-pham-bien-the/_o_t-shirt_c_tr_n_n_i9tsh009g-190k_4_.jpg\" x=\"-233\" y=\"-350\" width=\"466\" height=\"700\"></image>\n</g>\n<g transform=\"matrix(3.4 0 0 3.4 104.9 163.9)\"  >\n\t<image style=\"stroke: none; stroke-width: 0; stroke-dasharray: none; stroke-linecap: butt; stroke-dashoffset: 0; stroke-linejoin: miter; stroke-miterlimit: 4; fill: rgb(0,0,0); fill-rule: nonzero; opacity: 1;\"  xlink:href=\"https://localhost:44302/Images/item/favicon.png\" x=\"-8.5\" y=\"-8.5\" width=\"17\" height=\"17\"></image>\n</g>\n</svg>`
  },]
  message:string;
  ngOnInit(): void {
  this.service.getsptk()
  this.service.currentMessage.subscribe(message => this.message = message);
  }
  
  ngAfterViewInit(): void {
    this.service.dataSource.sort = this.sort;
    this.service.dataSource.paginator = this.paginator;
  }
  @Input()  childMessage: string;
  parentMessage: string = "Message from parent";
 onSelected(){
  this.router.navigate(['admin/sanphamthietke']);

 }

 doFilter = (value: string) => {
  this.service.dataSource.filter = value.trim().toLocaleLowerCase();
}
  clickDelete(id){
  if(confirm('Bạn có chắc chắn xóa bản ghi này không ??'))
  {
    this.service.delete(id).subscribe(
      res=>{
        this.toastService.showToastXoaThanhCong()
        this.service.getsptk()
      },err=>{
        this.toastService.showToastXoaThatBai()
      }
    )
}
}

}
export class GetSPTK{
  IdSP : number
  Hinh : string
  Name : string
  TrangThaiChoPhep : string
}