import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms'
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
            get Ten() { return this.newForm.get('Ten'); }
            get Gia() {return this.newForm.get('Gia'); }
            get KhuyenMai() { return this.newForm.get('KhuyenMai'); }
            get MoTa() { return this.newForm.get('MoTa'); }
            get Tag() { return this.newForm.get('Tag'); }
            get HuongDan() { return this.newForm.get('HuongDan'); }
            get ThanhPhan() { return this.newForm.get('ThanhPhan'); }

            get Id_Loai () { return this.newForm.get('Id_Loai'); }
            get Id_NhanHieu () { return this.newForm.get('Id_NhanHieu'); }
            get TrangThaiSanPhamThietKe() {return this.newForm.get('TrangThaiSanPhamThietKe'); }
            get TrangThaiSanPham() {return this.newForm.get('TrangThaiSanPham'); }
            get TrangThaiHoatDong() {return this.newForm.get('TrangThaiHoatDong'); }
          
          
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
      
   /*  this.http.get("https://localhost:44302/api/ImageSanPhams/"+this.service.product.id).subscribe(
      res=>{
        this.imageproductList = res as ImageProduct[]
        console.log( this.imageproductList)
      },
      error=>{
        
      }
    ) */
              this.newForm = new FormGroup({
                Ten : new FormControl(null,[
                  Validators.required,
                  Validators.minLength(2),
                  Validators.maxLength(15),
             

                ]),
                Gia : new FormControl(null,[
                  Validators.required,
                  Validators.min(3),
                  Validators.max(100000000000),
              
                ]),
                KhuyenMai : new FormControl(null,[
                  Validators.required,
                  Validators.min(1),
                  Validators.max(50000000000),
                  
                ]),
                MoTa : new FormControl(null,[
                  Validators.required,
                  Validators.minLength(10),
                  Validators.maxLength(100),
                 
                  
                ]),
                HuongDan : new FormControl(null,[
                  Validators.required,
                  Validators.minLength(10),
                  Validators.maxLength(100),
              
                  
                ]),
                ThanhPhan : new FormControl(null,[
                  Validators.required,
                  Validators.minLength(3),
                  Validators.maxLength(50),
             
                ]),
                Tag : new FormControl(null,[
                  Validators.required,
                  Validators.minLength(2),
                  Validators.maxLength(15),
             
                  
                ]),
                Id_Loai  : new FormControl(null,[
                  Validators.required,             
                  
                ]),
                Id_NhanHieu  : new FormControl(null,[
                  Validators.required,           
                  
                ]),
                TrangThaiSanPhamThietKe : new FormControl(null,[
                  Validators.required,                             
                ]),
                TrangThaiSanPham : new FormControl(null,[
                  Validators.required,
                ]),
                TrangThaiHoatDong : new FormControl(null,[
                  Validators.required,
                  
                ]),
             
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