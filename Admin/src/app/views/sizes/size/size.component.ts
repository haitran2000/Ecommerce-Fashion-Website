import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { SizesComponent } from '../sizes.component';
import { SizeService } from '../size.service';

@Component({
  selector: 'app-size',
  templateUrl: './size.component.html',
  styleUrls: ['./size.component.scss']
})
export class SizeComponent implements OnInit {
  public categorysComponent : SizesComponent
  constructor(public service : SizeService,
    public http :HttpClient ,
  ) {
  
   }
  
ngOnInit(): void {
this.newBlogForm = new FormGroup({
Ten: new FormControl(null),
Size : new FormControl(null)
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
formData.append('Ten', data.ten);
formData.append('Size1',data.ten);
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
formData.append('Ten', data.ten);
formData.append('Size1',data.ten);
this.http.put('https://localhost:44302/api/sizes/'+`${this.service.size.id}`, formData)
.subscribe(res=>{
  this.service.getAllSizes();
this.service.size.id=0;
});
}
}
}