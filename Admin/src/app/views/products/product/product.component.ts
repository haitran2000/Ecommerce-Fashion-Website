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
  public newForm: FormGroup;
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
  onSelectFile(fileInput: any) {
    this.selectedFile = <FileList>fileInput.target.files;
  }
  //End Review multile file before upload
  public Editor = ClassicEditor;
  selectedFile: FileList ;
 
  
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
                HuongDan : new FormControl(null),
                ThanhPhan : new FormControl(null),
                Tag : new FormControl(null),
                Id_Loai  : new FormControl(null),
                Id_NhanHieu  : new FormControl(null),
                TrangThaiSanPhamThietKe : new FormControl(null),
                TrangThaiSanPham : new FormControl(null),
                TrangThaiHoatDong : new FormControl(null),
                KhoiLuong : new FormControl(null),
                Gia : new FormControl(null),
              });
  } 
   
   
    clearForm() {
      this.newForm.reset();
     }


     onSubmit=(data) =>{
      if(this.service.product.id==0){
        let form = new FormData();
        form.append('Ten', data.Ten);
        form.append('KhuyenMai',data.KhuyenMai);
        form.append('MoTa', data.MoTa);
        form.append('Gia', data.Gia);
        form.append('HuongDan', data.HuongDan);
        form.append('ThanhPhan', data.ThanhPhan);
        form.append('Tag', data.Tag);
        form.append('Id_Loai', data.Id_Loai);
        form.append('Id_NhanHieu', data.Id_NhanHieu);
        form.append('TrangThaiSanPham',data.TrangThaiSanPham);
        form.append('TrangThaiSanPhamThietKe',data.TrangThaiSanPhamThietKe);
        form.append('TrangThaiHoatDong',data.TrangThaiHoatDong);
       var json_arr = JSON.stringify(data);
       console.log(json_arr)
        this.http.post('https://localhost:44302/api/sanphams', form)
        .subscribe(res => {
          this.resetForm()
         this.service.getAllProducts();
         this.service.product.id=0;
         this.onSelectedList();
         this.clearForm();
        });
      }
      else
      {
        const form = new FormData();
        form.append('Ten', data.Ten);
        form.append('KhuyenMai',data.KhuyenMai);
        form.append('MoTa', data.MoTa);
        form.append('HuongDan', data.HuongDan);
        form.append('ThanhPhan', data.ThanhPhan);
        form.append('Tag', data.Tag);
        form.append('Gia', data.Gia);
        form.append('Id_Loai', data.Id_Loai);
        form.append('Id_NhanHieu', data.Id_NhanHieu);
        form.append('TrangThaiSanPham',data.TrangThaiSanPham);
        form.append('TrangThaiSanPhamThietKe',data.TrangThaiSanPhamThietKe);
        form.append('TrangThaiHoatDong',data.TrangThaiHoatDong);
        this.http.put('https://localhost:44302/api/sanphams/'+`${this.service.product.id}`, form)
        .subscribe(res=>{
         this.resetForm()
          this.service.getAllProducts();
          this.service.product.id=0;
          this.onSelectedList();
          this.clearForm();
        });
    
      }
    }
    resetForm() {
      this.newForm.reset();
      this.service.product = new Product();
    }
  
  }
  export class ImageProduct{
    imagePath : string
    SanPhamId : number
  }