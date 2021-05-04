import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms'
import { ProductService } from '../product.service';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  //Begin Review multile file before upload
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
  //End Review multile file before upload
  public Editor = ClassicEditor;
  selectedFile: FileList;
  public newForm: FormGroup;
  onSelectFile(fileInput: any) {
    this.selectedFile = <FileList>fileInput.target.files;
  }
  constructor(public service : ProductService,
              public http: HttpClient,
              public router : Router) { }
              onSelected(){
                this.router.navigate(['products']);
            }
  ngOnInit(): void {
    this.newForm = new FormGroup({
      Ten : new FormControl(''),
      KhuyenMai : new FormControl(0),
      MoTa : new FormControl(''),
      SoLuong : new FormControl(0),
      TrangThaiSanPham : new FormControl(0),
      KhoiLuong : new FormControl(0),
      HuongDan : new FormControl(''),
      MauSac : new FormControl(''),
      ThanhPhan : new FormControl(''),
      ChatLieu : new FormControl(''),
      CreateBy : new FormControl(0),
      CreateDate : new FormControl(null),
      UpdateBy : new FormControl(0),
      UpdateDate : new FormControl(null),
      TrangThaiHoatDong : new FormControl("True"),
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
        form.append('TrangThaiSanPham','1');
        form.append('KhoiLuong', '10');
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
          if(this.onSelectFile!=null){
            for(let i = 0 ;i<this.selectedFile.length;i++){
              form.append('TileImage',this.selectedFile[i]);
            }
          }
         else{
              form.append('TileImage',null)
         }
        }
        catch(Ex){
          console.log(Ex)
        }
        
        form.append('TrangThaiHoatDong', 'True');
        form.append('CreateBy', '0');
        form.append('GiaSanPhams',null)
        form.append('SanPhamThietKes',null)
        form.append('SanPham_SanPhamThietKes',null)
       var json_arr = JSON.stringify(data);
       console.log(json_arr)
        this.http.post('https://localhost:44302/api/sanphams', form)
        .subscribe(res => {
         this.service.getAllProducts();
         this.service.product.id=0;
         this.onSelected();
         this.clearForm();
        });
      }
      else
      {
        const formData = new FormData();
        formData.append('Name', data.Name);
        formData.append('KhuyenMai', data.KhuyenMai);
        formData.append('MoTa', data.MoTa);
        formData.append('SoLuong', data.SoLuong);
        formData.append('TrangThaiSanPham', data.TrangThaiSanPham);
        formData.append('KhoiLuong', data.KhoiLuong);
        formData.append('HuongDan', data. HuongDan);
        formData.append('MauSac', data.MauSac);
        formData.append('ThanhPhan', data.ThanhPhan);
        formData.append('ChatLieu', data.ChatLieu);
        formData.append('CreateBy', data.CreateBy);
        formData.append('UpdateBy', data.UpdateBy);
        formData.append('CreateDate', data.CreateDate);
        formData.append('UpdateDate', data.UpdateDate);
        formData.append('TrangThaiHoatDong', data.TrangThaiHoatDong);
        formData.append('BrandId', data.BrandId);
        formData.append('CategoryId', data.CategoryId);
        for(let i = 0 ;i<this.selectedFile.length;i++){
          formData.append('TileImage',this.selectedFile[i]);
        }
        this.http.put('https://localhost:44302/api/sanphams/'+`${this.service.product.id}`, formData)
        .subscribe(res=>{
          this.service.getAllProducts();
          this.service.product.id=0;
          this.onSelected();
          this.clearForm();
        });
    
      }
    }
  }