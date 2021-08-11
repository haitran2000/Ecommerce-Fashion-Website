import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { Product, ProductService } from '../product.service';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { Router } from '@angular/router';

import { CategoryService } from '../../categories/category.service';
import { BrandService } from '../../brands/brand.service';
import { ToastServiceService } from '../../../shared/toast-service.service';
import { environment } from '../../../../../../environments/environment';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  public product: Product

  //Begin Review multile file before upload
  public newForm: FormGroup;
  urls = new Array<string>();
  gopHam(event) {
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
  selectedFile: FileList;


  categories: any[] = [];
  brands: any[] = [];
  constructor(public service: ProductService,
    public http: HttpClient,
    public router: Router,
    public serviceToast: ToastServiceService,
    public serviceCategory: CategoryService,
    public serviceBrand: BrandService) {
  }
  onSelectedList() {
    this.router.navigate(['admin/products']);

  }
  get Ten() { return this.newForm.get('Ten'); }
  get Gia() { return this.newForm.get('Gia'); }
  get GiaNhap() { return this.newForm.get('GiaNhap'); }
  get KhuyenMai() { return this.newForm.get('KhuyenMai'); }
  get MoTa() { return this.newForm.get('MoTa'); }
  get Tag() { return this.newForm.get('Tag'); }
  get HuongDan() { return this.newForm.get('HuongDan'); }
  get ThanhPhan() { return this.newForm.get('ThanhPhan'); }
  get Id_Loai() { return this.newForm.get('Id_Loai'); }
  get Id_NhanHieu() { return this.newForm.get('Id_NhanHieu'); }
  get TrangThaiSanPham() { return this.newForm.get('TrangThaiSanPham'); }
  get TrangThaiHoatDong() { return this.newForm.get('TrangThaiHoatDong'); }
  get GioiTinh(){return this.newForm.get('GioiTinh')}

  ngOnInit(): void {
    this.serviceCategory.get().subscribe(
      data => {
        Object.assign(this.categories, data)
      }
    )

    this.serviceBrand.get().subscribe(
      data => {
        Object.assign(this.brands, data)
      }
    )
    this.newForm = new FormGroup({

      Ten: new FormControl(null, [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(100),


      ]),
      Gia: new FormControl(null, [
        Validators.required,
        Validators.min(3),
        Validators.max(100000000000),

      ]),
      GiaNhap: new FormControl(null, [
        Validators.required,
        Validators.min(3),
        Validators.max(100000000000),

      ]),
      KhuyenMai: new FormControl(null, [
        Validators.required,
        Validators.min(0),
        Validators.max(50000000000),

      ]),
      MoTa: new FormControl(null, [
        Validators.required,
        Validators.minLength(10),
        Validators.maxLength(10000000000000),


      ]),
      HuongDan: new FormControl(null, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(1000000000000),


      ]),
      ThanhPhan: new FormControl(null, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(5000000000),

      ]),
      Tag: new FormControl(null, [
        Validators.required,
        Validators.minLength(2),
        Validators.maxLength(15),

      ]),
      Id_Loai: new FormControl( null, [
        Validators.required,

      ]),
      Id_NhanHieu: new FormControl(null, [
        Validators.required,

      ]),

      TrangThaiSanPham: new FormControl(null, [
        Validators.required,
      ]),
      TrangThaiHoatDong: new FormControl(null, [
        Validators.required,

      ]),
      GioiTinh: new FormControl(null, [
        Validators.required,

      ]),

    });
  }
  clearForm() {
    this.newForm.reset();
  }


  onSubmit = (data) => {
    if (this.service.product.id == 0) {
      let form = new FormData();
      for (let i = 0; i < this.urls.length; i++) {
        form.append('files', this.selectedFile.item(i))
      }
      form.append('Ten', data.Ten);
      form.append('KhuyenMai', data.KhuyenMai);
      form.append('MoTa', data.MoTa);
      form.append('Gia', data.Gia);
      form.append('GiaNhap', data.GiaNhap);
      form.append('HuongDan', data.HuongDan);
      form.append('ThanhPhan', data.ThanhPhan);
      form.append('Tag', data.Tag);
      form.append('GioiTinh',data.GioiTinh)
      form.append('Id_Loai', data.Id_Loai);
      form.append('Id_NhanHieu', data.Id_NhanHieu);
      form.append('TrangThaiSanPham', data.TrangThaiSanPham);
      form.append('TrangThaiHoatDong', data.TrangThaiHoatDong);
      var json_arr = JSON.stringify(data);
      console.log(json_arr)
      this.service.post(form)
        .subscribe(res => {
          this.serviceToast.showToastThemThanhCong()
          this.resetForm()
          this.service.getAllProducts();
          this.service.product.id = 0;
          this.onSelectedList();
          this.clearForm();
        }, err => {
          this.serviceToast.showToastThemThatBai()
        }
        );
    }
    else {
      const form = new FormData();
      form.append('Ten', data.Ten);
      form.append('KhuyenMai', data.KhuyenMai);
      form.append('MoTa', data.MoTa);
      form.append('Gia', data.Gia);
      form.append('GiaNhap', data.GiaNhap);
      form.append('GioiTinh',data.GioiTinh)
      form.append('HuongDan', data.HuongDan);
      form.append('ThanhPhan', data.ThanhPhan);
      form.append('Tag', data.Tag);
      form.append('Id_Loai', data.Id_Loai);
      form.append('Id_NhanHieu', data.Id_NhanHieu);
      form.append('TrangThaiSanPham', data.TrangThaiSanPham);
      form.append('TrangThaiSanPhamThietKe', data.TrangThaiSanPhamThietKe);
      for (let i = 0; i < this.urls.length; i++) {
        form.append('files', this.selectedFile.item(i))
      }
      form.append('TrangThaiHoatDong', data.TrangThaiHoatDong);
      this.service.put(this.service.product.id, form)
        .subscribe(res => {
          this.serviceToast.showToastSuaThanhCong()
          this.resetForm()
          this.service.getAllProducts();
          this.service.product.id = 0;
          this.onSelectedList();
          this.clearForm();
        }, err => {
          this.serviceToast.showToastSuaThatBai()
        });

    }
  }
  resetForm() {
    this.newForm.reset();
    this.service.product = new Product();
  }
}
