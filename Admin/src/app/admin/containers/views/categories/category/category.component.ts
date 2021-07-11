import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { error } from 'node:console';
import { ToastServiceService } from '../../../shared/toast-service.service';
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
    public toastService: ToastServiceService,
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

});
}
public newBlogForm: FormGroup;

onSubmit=(data) =>{
if(this.service.category.id==0){
const formData = new FormData();
formData.append('Name', data.Name);
this.http.post('https://cozastores.azurewebsites.net/api/loais', formData)
.subscribe(res => {
  this.toastService.showToastThemThanhCong();
this.service.getAllCategories();
this.service.category.id=0;
},err=>{
  this.toastService.showToastThemThatBai()
});
this.newBlogForm.reset();
}
else
{
const formData = new FormData();
formData.append('Name', data.Name);
this.http.put('https://cozastores.azurewebsites.net/api/loais/'+`${this.service.category.id}`, formData)
.subscribe(res=>{
  this.toastService.showToastSuaThanhCong();
  this.service.getAllCategories();
this.service.category.id=0;
},
error=>{
  this.toastService.showToastXoaThatBai()
});
}
}
}

function forbiddenNameValidator(arg0: RegExp): import("@angular/forms").ValidatorFn {
  throw new Error('Function not implemented.');
}
