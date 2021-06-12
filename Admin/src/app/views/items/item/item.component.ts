import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { FileToUploadService } from '../../../shared/file-to-upload.service';
import { ToastServiceService } from '../../../shared/toast-service.service';
import { ItemService } from '../item.service';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss']
})
export class ItemComponent implements OnInit {

  public imgsrc : string= "./assets/Resources/Images/san-pham-bien-the/blog-02.jpg";
  imgsrc1 : string= "./assets/Resources/Images/item/pin.png";
  fileChange(event) {
    if(event.target.files){
      var reader = new FileReader()
      reader.readAsDataURL(event.target.files[0])
      reader.onload = (event:any)=>{
        this.imgsrc = event.target.result
      }
    }
   

  }
  fileChange1(event) {
    if(event.target.files){
      var reader = new FileReader()
      reader.readAsDataURL(event.target.files[0])
      reader.onload = (event:any)=>{
        this.imgsrc1 =event.target.result;
      }
    }
  


  }
  constructor(public service :ItemService,
              public http :HttpClient ,
              public serviceToast : ToastServiceService,
              public upfile:FileToUploadService
              ){
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
        this.fileChange1(event)
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
      up(){
        const formData = new FormData();
      
        formData.append('file', this.selectedFile.item(0));
        this.http.post('https://localhost:5001/api/getsanphamthuongdethietkes/file', formData)
        .subscribe(res => {
          this.serviceToast.showToastThemThanhCong()
        this.service.getAllItems();
        this.service.item.id=0;
        });
      }
      onSubmit=(data) =>{
      if(this.service.item.id==0){
        this.up()
      const formData = new FormData();
      formData.append('TrangThai', data.TrangThai);
      formData.append('TileImage', this.selectedFile.item(0));
      console.log(data)
      this.http.post('https://localhost:5001/api/items', formData)
      .subscribe(res => {
        this.serviceToast.showToastThemThanhCong()
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
      this.http.put('https://localhost:5001/api/items/'+`${this.service.item.id}`, formData)
      .subscribe(res=>{
        this.serviceToast.showToastSuaThanhCong()
        this.service.getAllItems();
        this.service.item.id=0;
      });
      }
      }
      }