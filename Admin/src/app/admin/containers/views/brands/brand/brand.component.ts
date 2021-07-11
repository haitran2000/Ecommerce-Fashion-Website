import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BrandsComponent } from '../brands.component';
import { BrandService } from '../brand.service';
import { ToastrService } from 'ngx-toastr';
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.scss']
})
export class BrandComponent implements OnInit {

  public BrandsComponent : BrandsComponent
  constructor(  public service : BrandService,
                public http :HttpClient ,
                public toastr: ToastrService,
              ) {
             
                }
get name() { return this.newBlogForm.get('Name'); }
get ThongTin() { return this.newBlogForm.get('ThongTin'); }

ngOnInit(): void {
this.newBlogForm = new FormGroup({
Name: new FormControl(null,
  [
    Validators.required,
    Validators.minLength(2),
  ]),
ThongTin: new FormControl(null,
  [
    Validators.required,
    Validators.minLength(5),
  ]),
TileImage : new FormControl(null,
  [
    Validators.required,
  ]
  )
});
}

public newBlogForm: FormGroup;



showToastThemThanhCong(){
  this.toastr.success("Thêm thành công")
}
showToastSuaThanhCong(){
  this.toastr.success("Sửa thành công")
}
showToastThemThatBai(){
  this.toastr.error("Thêm thất bại")
}
showToastSuaThatBai(){
  this.toastr.error("Sửa thất bại")
}
onSubmit=(data) =>{
if(this.service.brand.id==0){
const formData = new FormData();
formData.append('Name', data.Name);

console.log(data)
this.http.post('https://cozastores.azurewebsites.net/api/nhanhieus', formData)
.subscribe(res => {
  this.showToastThemThanhCong()
this.service.getAllBrands();
this.service.brand.id=0;
},
err=>{
  this.showToastThemThatBai()
});
this.newBlogForm.reset();
}
else
{
const formData = new FormData();
formData.append('Name', data.Name);
formData.append('ThongTin', data.ThongTin);
this.http.put('https://cozastores.azurewebsites.net/api/nhanhieus/'+`${this.service.brand.id}`, formData)
.subscribe(res=>{
  this.showToastSuaThanhCong()
  this.service.getAllBrands();
this.service.brand.id=0;
},
err=>{
  this.showToastSuaThatBai()
});
}
}
}