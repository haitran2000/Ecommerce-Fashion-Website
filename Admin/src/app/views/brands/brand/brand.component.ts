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
selectedFile: FileList ;
urls = new Array<string>();
gopHam(event){
  this.detectFiles(event)
  this.onSelectFile(event)
}
detectFiles(event) {
  this.urls = [];
  let files = event.target.files;
    for (let file of files) {
      let reader = new FileReader();
      reader.onload = (e: any) => {
        this.urls.push(e.target.result);
      }
      reader.readAsDataURL(file);
    }
}
checkFileSize(){
  if(this.selectedFile.item(0).size < 5000 ){
    return true
  }
  return false
}
onSelectFile(fileInput: any) {
  this.selectedFile = <FileList>fileInput.target.files;
}
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
formData.append('ThongTin', data.ThongTin);
formData.append('TileImage', this.selectedFile.item(0));
console.log(data)
this.http.post('https://localhost:5001/api/nhanhieus', formData)
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
formData.append('TileImage', this.selectedFile.item(0));
this.http.put('https://localhost:5001/api/nhanhieus/'+`${this.service.brand.id}`, formData)
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