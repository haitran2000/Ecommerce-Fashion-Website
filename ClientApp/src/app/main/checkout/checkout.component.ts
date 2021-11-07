import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Swal from 'sweetalert2';
import { CartService } from 'src/app/service/product.service';
import { UserService } from 'src/app/service/account/user.service';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit  {

  list_item:any;
  tongtien:any;
   Tinh: string;
   Xa: string;
   MaGiamGia: string;
   Huyen: string;
   DiaChi: string;
   list_MGG :any;
   list_MGGSD:string[];
   check:any;
   check_sudung:any;
   tongThanhToan:any;
   list_tinh_thanh: any;
   list_quan_huyen: any;
   list_xa_phuong: any;
  constructor(public http:HttpClient,private cartService: CartService,private userService: UserService,public router:Router) {
    userService.checkLogin();
    const clicks = localStorage.getItem('idUser');
    this.Tinh=null;
    this.http.get("https://provinces.open-api.vn/api/?depth=3").subscribe(res=>{
      this.list_tinh_thanh=res;
    } );
    this.http.post(environment.URL_API+"Carts/getCart/"+clicks,{}).subscribe(
      res=>{
        this.list_item = res;
        this.tongtien=0;
        for (let i = 0; i < this.list_item.length; i++) {
            this.tongtien=this.tongtien+(this.list_item[i].productDetail.gia*this.list_item[i].soLuong);
          this.tongThanhToan=this.tongtien+25000;
        }
      });
    this.http.get(environment.URL_API+"hoadons/magiamgia/").subscribe(res=>{
      this.list_MGG=res;
    } );

    this.list_MGGSD=[];
    this.check=null;
  }

 deleteSanPham(item):void {
  const clicks = localStorage.getItem('idUser');
  this.http.post(environment.URL_API+"carts/delete",{
    Id_sanpham:item.idSanPhamBienThe,
    User_ID:clicks
  }).subscribe(
    res=>{
      Swal.fire("Xoá sản phẩm thành công .", '', 'success')
      this.http.post(environment.URL_API+"Carts/getCart/"+clicks,{}).subscribe(
      res=>{
        this.list_item = res;
        this.tongtien=0;
        for (let i = 0; i < this.list_item.length; i++) {
            this.tongtien=this.tongtien+(this.list_item[i].productDetail.gia*this.list_item[i].soLuong);
          this.tongThanhToan=this.tongtien+25000;
        }
        this.cartService.DeleteProduct(item.productDeatail);
      });
    })

}
  ngOnInit(): void {
}
  maGiamGia():void{
    if (localStorage.getItem("products") === null) {
      Swal.fire("Giỏ hàng trống.", '', 'warning').then(function () {
      }
      )
    }
    else
    {


    this.check = this.list_MGG.filter(d=>d.myCode==this.MaGiamGia)[0];
    this.check_sudung = this.list_MGGSD.filter(d=>d==this.MaGiamGia)[0];
    if(this.check!=null&&this.check_sudung==null)
    {

      this.list_MGGSD.push(this.MaGiamGia)
      this.tongThanhToan=this.tongtien+25000-this.check.soTienGiam;
      Swal.fire("Áp dụng mã giảm giá thành công .", '', 'success')
    }
    else{
      if(this.check_sudung==this.MaGiamGia)
      {
        Swal.fire("Bạn đã áp mã này rồi.", '', 'error')
      }
      else
      {
        Swal.fire("Mã giảm giá không tồn tại .", '', 'error')
      }

    }
  }

  }
  onSubmit(){
    if (localStorage.getItem("products") === null) {
      Swal.fire("Giỏ hàng trống.", '', 'warning').then(function () {
      }
      )
    }
    else
    {
      const clicks = localStorage.getItem('idUser');
    this.http.post(environment.URL_API+"hoadons/",{
      Tinh:this.Tinh,
      Huyen:this.Huyen,
      Xa:this.Xa,
      DiaChi:this.DiaChi,
      TongTien:this.tongThanhToan-25000,
      Id_User:clicks

    }).subscribe(
      res=>{
        Swal.fire("Đặt hàng thành công.", '', 'success').then(function () {
          window.location.href='/history';
          localStorage.removeItem('products');
      }
    );
  })
    }

}
  updateCongSanPham(cartID,soLuong){
    const clicks = localStorage.getItem('idUser');

    this.http.post(environment.URL_API+"Carts/update/",{
    CartID:cartID,
    SoLuong:soLuong+1,
    UserID:clicks
    }).subscribe(
      res=>{
        this.list_item=res;
        this.tongtien=0;
        for (let i = 0; i < this.list_item.length; i++) {
            this.tongtien=this.tongtien+(this.list_item[i].productDetail.gia*this.list_item[i].soLuong);
          this.tongThanhToan=this.tongtien+25000;
        }

      }

    );
    this.tongThanhToan=this.tongtien+25000-this.check.soTienGiam;

  }
  updateTruSanPham(cartID,soLuong){
    const clicks = localStorage.getItem('idUser');
    if(soLuong==1)
    {
      soLuong=0;
    }
    else
    {
      soLuong=soLuong-1;
    }
    this.http.post(environment.URL_API+"Carts/update/",{
    CartID:cartID,
    SoLuong:soLuong,
    UserID:clicks
    }).subscribe(
      res=>{
        this.list_item=res;
        this.tongtien=0;
        for (let i = 0; i < this.list_item.length; i++) {
            this.tongtien=this.tongtien+(this.list_item[i].productDetail.gia*this.list_item[i].soLuong);
          this.tongThanhToan=this.tongtien+25000;
        }
        }

    );
    this.tongThanhToan=this.tongtien+25000-this.check.soTienGiam;

  }
  changTinhThanh(event:any):void{
    this.Tinh=event;
    const tinh = event;
    const search =this.list_tinh_thanh.filter(d=>d.name===tinh)[0];
    this.list_quan_huyen=search.districts;
  }
  changHuyenQuan(event:any):void{
    this.Huyen=event;
    const Huyen = event;
    const search =this.list_quan_huyen.filter(d=>d.name===Huyen)[0];
    this.list_xa_phuong=search.wards;
  }

}
