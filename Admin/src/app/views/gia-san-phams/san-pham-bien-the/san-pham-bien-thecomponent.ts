import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CategoryService } from '../../categories/category.service';
import { MauSacService } from '../../mau-sacs/mau-sac.service';
import { ProductService } from '../../products/product.service';
import { SizeService } from '../../sizes/size.service';
import { Size } from '../../sizes/sizes.component';
import { SanPhamBienTheService } from '../san-pham-bien-the.service';

@Component({
  selector: 'app-san-pham-bien-the',
  templateUrl: './san-pham-bien-the.component.html',
  styleUrls: ['./san-pham-bien-the.component.scss']
})
export class SanPhamBienTheComponent implements OnInit {
  urls = new Array<string>();
  selectedFile: File = null;
  detectFiles(event) {
  
    let files = event.target.files;
      for (let file of files) {
        let reader = new FileReader();
        reader.onload = (e: any) => {
          this.urls.push(e.target.result);
        }
        reader.readAsDataURL(file);
      }
  }
  onSelectFile(fileInput: any) {
    this.selectedFile = <File>fileInput.target.files[0];
  }
  gopHam(event){
    this.detectFiles(event)
    this.onSelectFile(event)
  }
  categorys: any[] = [];
  mausacs: any[] = [];
  sanphams: any[] = [];
  sizes: any[] = [];
  constructor(public service : SanPhamBienTheService,
    
    public serviceCategory : CategoryService,
    public serviceSanPham : ProductService,
    
    public http :HttpClient ) {
                            
                              }
  get Id_Mau() { return this.newBlogForm.get('Id_Mau'); }
  get Id_SanPham() { return this.newBlogForm.get('Id_SanPham'); }
  get Id_Size() { return this.newBlogForm.get('Id_Size'); }


ngOnInit(): void {
this.newBlogForm = new FormGroup({
ImagePath : new FormControl(null), 
Id_Mau : new FormControl(null,[
  Validators.required,
]),
Id_SanPham : new FormControl(null,[
  Validators.required,
]),
Id_Size : new FormControl(null,[
  Validators.required,
]),
});


this.http.get("https://localhost:44302/api/mausacs").subscribe(
  data=>{
        Object.assign(this.mausacs,data)
        }
    )

    this.serviceCategory.get().subscribe(
      data=>{
            Object.assign(this.categorys,data)
            }
        )
  this.serviceSanPham.get().subscribe(
  data=>{
  Object.assign(this.sanphams,data)
        }
    )
  this.http.get("https://localhost:44302/api/sizes").subscribe(
  data=>{
          this.sizes = data as Size[]
        }
    )
}
public newBlogForm: FormGroup;

onSubmit=(data) =>{
if(this.service.sanphambienthe.id==0){
const formData = new FormData();

formData.append('MauId',data.Id_Mau);
formData.append('SanPhamId',data.Id_SanPham);
formData.append('SizeId',data.Id_Size);
formData.append('file', this.selectedFile);
console.log(data);

this.http.post('https://localhost:44302/api/sanphambienthes',formData)
.subscribe(res => {
this.service.getAllSanPhamBienThes();
this.service.sanphambienthe.id=0;
});
this.newBlogForm.reset();
}
else
{
const formData = new FormData();
formData.append('MauId',data.Id_Mau);
formData.append('SanPhamId',data.Id_SanPham);
formData.append('SizeId',data.Id_Size);
formData.append('file', this.selectedFile);
this.http.put('https://localhost:44302/api/sanphambienthes/'+`${this.service.sanphambienthe.id}`, formData)
.subscribe(res=>{
  this.service.getAllSanPhamBienThes();
  this.service.sanphambienthe.id=0;
});
}
}
}