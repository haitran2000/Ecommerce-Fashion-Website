import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ItemService } from '../item.service';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss']
})
export class ItemComponent implements OnInit {

  constructor(  public service :ItemService,
    public http :HttpClient ,
  ) {
    }
    get TrangThai() { return this.newBlogForm.get('TrangThai'); }
    ngOnInit(): void {
      this.newBlogForm = new FormGroup({
      TrangThai: new FormControl(null),
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
      if(this.service.item.id==0){
      const formData = new FormData();
      formData.append('TrangThai', data.TrangThai);
      formData.append('TileImage', this.selectedFile.item(0));
      console.log(data)
      this.http.post('https://localhost:44302/api/items', formData)
      .subscribe(res => {
      this.service.getAllItems();
      this.service.item.id=0;
      });
      this.newBlogForm.reset();
      }
      else
      {
      const formData = new FormData();
      formData.append('TrangThai', data.TrangThai);
      formData.append('TileImage', this.selectedFile.item(0));
      this.http.put('https://localhost:44302/api/items/'+`${this.service.item.id}`, formData)
      .subscribe(res=>{
        this.service.getAllItems();
        this.service.item.id=0;
      });
      }
      }
      }