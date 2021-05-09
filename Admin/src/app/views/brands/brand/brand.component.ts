import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BrandsComponent } from '../brands.component';
import { BrandService } from '../brand.service';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.scss']
})
export class BrandComponent implements OnInit {
  public categorysComponent : BrandsComponent
  constructor(public service : BrandService,
    public http :HttpClient ,
  ) {
  
   }
  
ngOnInit(): void {
this.newBlogForm = new FormGroup({
Name: new FormControl(null),
TileImage : new FormControl(null)
});
}

selectedFile: File = null;
public newBlogForm: FormGroup;
onSelectFile(fileInput: any) {
this.selectedFile = <File>fileInput.target.files[0];
}
onSubmit=(data) =>{
if(this.service.category.id==0){
const formData = new FormData();
formData.append('Name', data.Name);
formData.append('TileImage', this.selectedFile);
this.http.post('https://localhost:44302/api/thuonghieus', formData)
.subscribe(res => {
this.service.getAllBrands();
this.service.category.id=0;
});
this.newBlogForm.reset();
}
else
{
const formData = new FormData();
formData.append('Name', data.Name);
formData.append('TileImage', this.selectedFile);
this.http.put('https://localhost:44302/api/thuonghieus/'+`${this.service.category.id}`, formData)
.subscribe(res=>{
  this.service.getAllBrands();
this.service.category.id=0;
});
}
}
}