import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { SizesComponent } from '../sizes.component';
import { SizeService } from '../size.service';
import { CategoryService } from '../../categories/category.service';

@Component({
  selector: 'app-size',
  templateUrl: './size.component.html',
  styleUrls: ['./size.component.scss']
})
export class SizeComponent implements OnInit {
  categories: any[] = [];
  public categorysComponent : SizesComponent
  constructor(public service : SizeService,
    public http :HttpClient ,
    public serviceCategory : CategoryService,
  )  {
    this.serviceCategory.get().subscribe(
      data=>{
        Object.assign(this.categories,data)
      }
      )
   }
  
ngOnInit(): void {
this.newBlogForm = new FormGroup({
LoaiId: new FormControl(null),
Size1 : new FormControl(null)
});
}

selectedFile: File = null;
public newBlogForm: FormGroup;
onSelectFile(fileInput: any) {
this.selectedFile = <File>fileInput.target.files[0];
}
onSubmit=(data) =>{
if(this.service.size.id==0){
const formData = new FormData();
formData.append('LoaiId', data.LoaiId);
formData.append('Size1',data.Size1);
this.http.post('https://localhost:44302/api/sizes', formData)
.subscribe(res => {
this.service.getAllSizes();
this.service.size.id=0;
});
this.newBlogForm.reset();
}
else
{
const formData = new FormData();
formData.append('LoaiId', data.LoaiId);
formData.append('Size1',data.Size1);
this.http.put('https://localhost:44302/api/sizes/'+`${this.service.size.id}`, formData)
.subscribe(res=>{
  this.service.getAllSizes();
this.service.size.id=0;
});
}
}
}