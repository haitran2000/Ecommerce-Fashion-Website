import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CategoriesComponent } from '../categories.component';
import { CategoryService } from '../category.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {
  public categorysComponent : CategoriesComponent
  constructor(public service : CategoryService,
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
this.http.post('https://localhost:44302/api/loais', formData)
.subscribe(res => {
this.service.getAllCategories();
this.service.category.id=0;
});
this.newBlogForm.reset();
}
else
{
const formData = new FormData();
formData.append('Name', data.Name);
formData.append('TileImage', this.selectedFile);
this.http.put('https://localhost:44302/api/loais/'+`${this.service.category.id}`, formData)
.subscribe(res=>{
  this.service.getAllCategories();
this.service.category.id=0;
});
}
}
}