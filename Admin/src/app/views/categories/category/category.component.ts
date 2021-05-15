import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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
   get name() { return this.newBlogForm.get('Name'); }
ngOnInit(): void {
this.newBlogForm = new FormGroup({
Name: new FormControl("",
  [
    Validators.required,
    Validators.minLength(2),
  ]),
TileImage : new FormControl(null)
});
}
public newBlogForm: FormGroup;

selectedFile: FileList ;
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
onSubmit=(data) =>{
if(this.service.category.id==0){
const formData = new FormData();
formData.append('Name', data.Name);
formData.append('TileImage', this.selectedFile.item(0));
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
formData.append('TileImage', this.selectedFile.item(0));
this.http.put('https://localhost:44302/api/loais/'+`${this.service.category.id}`, formData)
.subscribe(res=>{
  this.service.getAllCategories();
this.service.category.id=0;
});
}
}
}

function forbiddenNameValidator(arg0: RegExp): import("@angular/forms").ValidatorFn {
  throw new Error('Function not implemented.');
}
