import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CategoryService } from '../../categories/category.service';
import { MauSacService } from '../../mau-sacs/mau-sac.service';
import { ProductService } from '../../products/product.service';
import { SizeService } from '../../sizes/size.service';
import { Size } from '../../sizes/sizes.component';
import { GiaSanPhamService } from '../gia-san-pham.service';

@Component({
  selector: 'app-gia-san-pham',
  templateUrl: './gia-san-pham.component.html',
  styleUrls: ['./gia-san-pham.component.scss']
})
export class GiaSanPhamComponent implements OnInit {

  categorys: any[] = [];
  mausacs: any[] = [];
  sanphams: any[] = [];
  sizes: any[] = [];
  constructor(public service : GiaSanPhamService,
    
    public serviceCategory : CategoryService,
    public serviceSanPham : ProductService,
    
    public http :HttpClient ) {
                            
                              }
  
ngOnInit(): void {
this.newBlogForm = new FormGroup({
Gia: new FormControl(null),
MauId : new FormControl(null),
SanPhamId : new FormControl(null),
SizeId : new FormControl(null),
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
if(this.service.giasanpham.id==0){
const formData = new FormData();
formData.append('Gia', data.Gia);
formData.append('MauId',data.MauId);
formData.append('SanPhamId',data.SanPhamId);
formData.append('SizeId',data.SizeId);
console.log(data);
console.log(formData.forEach);
this.http.post('https://localhost:44302/api/giasanphams',formData)
.subscribe(res => {
this.service.getAllGiaSanPhams();
this.service.giasanpham.id=0;
});
this.newBlogForm.reset();
}
else
{
const formData = new FormData();
formData.append('Gia', data.Gia);
formData.append('MauId',data.MauId);
formData.append('SanPhamId',data.SanPhamId);
formData.append('SizeId',data.SizeId);
this.http.put('https://localhost:44302/api/giasanphams/'+`${this.service.giasanpham.id}`, formData)
.subscribe(res=>{
  this.service.getAllGiaSanPhams();
  this.service.giasanpham.id=0;
});
}
}
}