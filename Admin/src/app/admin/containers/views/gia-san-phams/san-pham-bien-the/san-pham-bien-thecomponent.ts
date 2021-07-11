import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { FileToUploadService } from '../../../shared/file-to-upload.service';
import { ToastServiceService } from '../../../shared/toast-service.service';
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
 
  public imgsrc : string= "./assets/Resources/Images/san-pham-bien-the/blog-02.jpg";
  public imgsrc1 : string= "./assets/Resources/Images/item/pin.png";
  fileChange(event) {
    var reader = new FileReader()
    reader.readAsDataURL(event.target.files[0])
    reader.onload = (event:any)=>{
      this.imgsrc = event.target.result
    }

  }
  fileChange1(event) {
    
    var reader = new FileReader()
    reader.readAsDataURL(event.target.files[0])
    reader.onload = (event:any)=>{
      this.imgsrc1 =event.target.result
    }


  }
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
    this.fileChange(event)
  }
  categorys: any[] = [];
  mausacs: any[] = [];
  sanphams: any[] = [];
  sizes: any[] = [];
  constructor(public service : SanPhamBienTheService,
    public upfile:FileToUploadService,
    public serviceToast : ToastServiceService,
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


this.http.get("https://cozastores.azurewebsites.net/api/mausacs").subscribe(
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
  this.http.get("https://cozastores.azurewebsites.net/api/sizes").subscribe(
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

this.http.post('https://cozastores.azurewebsites.net/api/sanphambienthes',formData)
.subscribe(res => {
  this.serviceToast.showToastThemThanhCong()
this.service.getAllSanPhamBienThes();
this.service.sanphambienthe.id=0;
},err=>{
  this.serviceToast.showToastThemThatBai()
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
this.http.put('https://cozastores.azurewebsites.net/api/sanphambienthes/'+`${this.service.sanphambienthe.id}`,formData)
.subscribe(res=>{
  this.serviceToast.showToastSuaThanhCong()
  this.service.getAllSanPhamBienThes();
  this.service.sanphambienthe.id=0;
},err=>{
  this.serviceToast.showToastSuaThatBai()
});
}
}
}