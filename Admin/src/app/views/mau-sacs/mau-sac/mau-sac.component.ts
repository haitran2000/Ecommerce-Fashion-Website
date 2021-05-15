import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MauSacsComponent } from '../mau-sacs.component';
import { MauSacService } from '../mau-sac.service';
import { CategoryService } from '../../categories/category.service';

@Component({
  selector: 'app-mau-sac',
  templateUrl: './mau-sac.component.html',
  styleUrls: ['./mau-sac.component.scss']
})
export class MauSacComponent implements OnInit {
 
  categories: any[] = [];
  constructor ( public service : MauSacService,
                public serviceCategory : CategoryService,
                public http :HttpClient ,
              ) {
                  this.serviceCategory.get().subscribe(
                  data=>{
                        Object.assign(this.categories,data)
                        }
                  )
      
                }
get MaMau() { return this.newBlogForm.get('MaMau'); }
get Id_Loai() { return this.newBlogForm.get('Id_Loai'); }

ngOnInit(): void {
this.newBlogForm = new FormGroup({
MaMau: new FormControl(null,
  [
    Validators.required,
    Validators.minLength(2),
  ]),
Id_Loai : new FormControl(null,
  [
    Validators.required,
  ])
});
}

selectedFile: File = null;
public newBlogForm: FormGroup;

onSubmit=(data) =>{
if(this.service.mausac.id==0){
const formData = new FormData();
formData.append('MaMau',data.MaMau);
formData.append('Id_Loai', data.Id_Loai);
this.http.post('https://localhost:44302/api/mausacs', formData)
.subscribe(res => {
this.service.getAllMauSacs();
this.service.mausac.id=0;
});
this.newBlogForm.reset();
}
else
{
const formData = new FormData();
formData.append('MaMau',data.MaMau);
formData.append('Id_Loai', data.Id_Loai);
this.http.put('https://localhost:44302/api/mausacs/'+`${this.service.mausac.id}`, formData)
.subscribe(res=>{
  this.service.getAllMauSacs();
this.service.mausac.id=0;
});
}
}
}