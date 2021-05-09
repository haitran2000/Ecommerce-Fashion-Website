import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms'
import { ProductService } from '../product.service';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { Router } from '@angular/router';
import { Product } from '../product.model';
import { CategoryService } from '../../categories/category.service';
import { BrandService } from '../../brands/brand.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  public product: Product
  public imageproductList : ImageProduct[]
  //Begin Review multile file before upload
  urls = new Array<string>();
  public newForm: FormGroup;
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
  //End Review multile file before upload
  public Editor = ClassicEditor;
  selectedFile: FileList ;
 
  onSelectFile(fileInput: any) {
    this.selectedFile = <FileList>fileInput.target.files;
  }
  categories: any[] = [];
  brands: any[]=[];
  constructor(public service : ProductService,
              public http: HttpClient,
              public router : Router,
              public serviceCategory : CategoryService,
              public serviceBrand : BrandService) {

                
               }
              onSelectedList(){
                this.router.navigate(['products']);
              
            }
  ngOnInit(): void {
    this.serviceCategory.get().subscribe(
      data=>{
        Object.assign(this.categories,data)
      }
      )

      this.serviceBrand.get().subscribe(
        data=>{
          Object.assign(this.brands,data)
        }
      )
    this.http.get("https://localhost:44302/api/ImageSanPhams/"+this.service.product.id).subscribe(
      res=>{
        this.imageproductList = res as ImageProduct[]
        console.log( this.imageproductList)
      },
      error=>{
        
      }
    )
              this.newForm = new FormGroup({
                Ten : new FormControl(null),
                KhuyenMai : new FormControl(null),
                MoTa : new FormControl(null),
                SoLuong : new FormControl(null),
                TrangThaiSanPham : new FormControl(null),
                KhoiLuong : new FormControl(null),
                HuongDan : new FormControl(null),
                MauSac : new FormControl(null),
                ThanhPhan : new FormControl(null),
                ChatLieu : new FormControl(null),
                CreateBy : new FormControl(null),
                CreateDate : new FormControl(null),
                UpdateBy : new FormControl(null),
                UpdateDate : new FormControl(null),
                TrangThaiHoatDong : new FormControl(null),
                BrandId  : new FormControl(null),
                CategoryId  : new FormControl(null),
                BillInfor  : new FormControl(null),
                TileImage : new FormControl(null),
                GiaSanPhams : new FormControl(null),
                SanPhamThietKes : new FormControl(null),
                SanPham_SanPhamThietKes : new FormControl(null),
              });
  } 
   
    clearForm() {
      this.newForm.reset();
     }


     onSubmit=(data) =>{
      if(this.service.product.id==0){
        let form = new FormData();
        form.append('Ten', data.Ten);
        form.append('KhuyenMai','0');
        form.append('MoTa', data.MoTa);
        form.append('SoLuong', '10');
        form.append('KhoiLuong', '10');
        form.append('TrangThaiSanPham', 'True');
        form.append('HuongDan', data.HuongDan);
        form.append('MauSac', data.MauSac);
        form.append('ThanhPhan', data.ThanhPhan);
        form.append('ChatLieu', data.ChatLieu);
        form.append('UpdateBy', '0');
        form.append('CreateDate', data.CreateDate);
        form.append('UpdateDate', data.UpdateDate);
        form.append('BrandId', data.BrandId);
        form.append('CategoryId', data.CategoryId);
        try{
       
            for(let i = 0 ;i<this.selectedFile.length;i++){
              form.append('ListImage',this.selectedFile[i]);
            }

        }
        catch(Ex){
          form.append('ListImage',null);
        }
      
        form.append('TrangThaiHoatDong', 'True');
        form.append('CreateBy', '0');
        form.append('GiaSanPhams','')
        form.append('SanPhamThietKes','')
        form.append('SanPham_SanPhamThietKes','') 
       var json_arr = JSON.stringify(data);
       console.log(json_arr)
        this.http.post('https://localhost:44302/api/sanphams', form)
        .subscribe(res => {
         this.service.getAllProducts();
         this.service.product.id=0;
         this.onSelectedList();
         this.clearForm();
        });
      }
      else
      {
        const formData = new FormData();
        formData.append('Ten', data.Ten);
        formData.append('KhuyenMai', data.KhuyenMai);
        formData.append('MoTa', data.MoTa);
        formData.append('SoLuong', data.SoLuong);
        formData.append('TrangThaiSanPham', 'True');
        formData.append('KhoiLuong', data.KhoiLuong);
        formData.append('HuongDan', data. HuongDan);
        formData.append('MauSac', data.MauSac);
        formData.append('ThanhPhan', data.ThanhPhan);
        formData.append('ChatLieu', data.ChatLieu);
        formData.append('CreateBy', '');
        formData.append('UpdateBy', '');
        formData.append('CreateDate', data.CreateDate);
        formData.append('UpdateDate', data.UpdateDate);
        formData.append('TrangThaiHoatDong', '');
        formData.append('BrandId', data.BrandId);
        formData.append('CategoryId', data.CategoryId);
        try{
       
          for(let i = 0 ;i<this.selectedFile.length;i++){
            formData.append('ListImage',this.selectedFile[i]);
          }

      }
      catch(Ex){
        formData.append('ListImage',null);
      }
        formData.append('TrangThaiHoatDong', 'True');
        formData.append('CreateBy', '0');
        formData.append('GiaSanPhams','')
        formData.append('SanPhamThietKes','')
        formData.append('SanPham_SanPhamThietKes','') 
        this.http.put('https://localhost:44302/api/sanphams/'+`${this.service.product.id}`, formData)
        .subscribe(res=>{
          this.service.getAllProducts();
          this.service.product.id=0;
          this.onSelectedList();
          this.clearForm();
        });
    
      }
    }
  }
  export class ImageProduct{
    imagePath : string
    SanPhamId : number
  }