import { AfterViewInit, Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FabricjsEditorComponent } from '../../../../../../../projects/angular-editor-fabric-js/src/public-api';

import {MatDialog} from '@angular/material/dialog';
import { ModaSaveComponent } from './moda-save/moda-save.component';
import { SanPhamThietKeService } from '../san-pham-thiet-ke.service';
import { ItemService } from '../../items/item.service';
import { HttpClient } from '@angular/common/http';
import { ActivationStart, Router, RouterOutlet } from '@angular/router';
import { JSONCanvasHelper } from '../models/jsoncanvas.model';
import { SanPhamBienThe } from '../../gia-san-phams/san-pham-bien-thes.component';
import * as htmlToImage from 'html-to-image';
import { toPng, toJpeg, toBlob, toPixelData, toSvg } from 'html-to-image';
import { FileToUploadService } from '../../../shared/file-to-upload.service';
import { SanPhamBienTheService } from '../../gia-san-phams/san-pham-bien-the.service';
import { ToastServiceService } from '../../../shared/toast-service.service';



@Component({
  selector: 'app-san-pham-thiet-ke',
  templateUrl: './san-pham-thiet-ke.component.html',
  styleUrls: ['./san-pham-thiet-ke.component.scss']
})
export class SanPhamThietKeComponent implements OnInit  {
  /**
   *
   */

   newMessage() {
    this.service.changeMessage('Hello from Sibling');
  }
   node: HTMLElement;
   
   fakeClick(){
    this.node = document.getElementById('canvas') as HTMLElement;
    htmlToImage.toJpeg(this.node)
    .then(function (dataUrl) {
      var img = new Image();
      img.crossOrigin="anonymous"
      img.src = dataUrl;
      const w = window.open('');
      w.document.write(img.outerHTML);
  
    })
    .catch(function (error) {
      console.error('oops, something went wrong!', error);
    });
  }
  @ViewChild('myDiv') myDiv: ElementRef;
  @Input() spbt = SanPhamBienThe 
  url: string
  urls:Array<string> = [];
  id: number
  idflags : Array<string> = [];
  public ad: asd = new asd()
public items : asd[]
public spbts: SanPhamBienThe[];
  constructor( private router: Router, public serviceToast: ToastServiceService, public dialog: MatDialog,public servicess:SanPhamBienTheService,public service : SanPhamThietKeService, public serviceItem: ItemService , public http: HttpClient) {
  }
  message: string;
  ngOnInit(): void {
    this.service.currentMessage.subscribe(message => this.message = message);
    this.serviceItem.getAllItems()
//     this.http.get("https://cozastores.azurewebsites.net/api/items").subscribe(res=>{
//   this.items = res as asd[]
//   console.log(this.items)
 
// })
this.http.get("https://cozastores.azurewebsites.net/api/GetSanPhamThuongDeThietKes").subscribe(
  res=>{
    this.spbts = res as SanPhamBienThe[];
  }
)
   
    this.serviceItem.getAllItemss();
    this.router.events.subscribe(e => {
      if (e instanceof ActivationStart && e.snapshot.outlet === "sanphamthietke")
        this.outlet.deactivate();
    });
  }
  title = 'angular-editor-fabric-js';
  @ViewChild(RouterOutlet) outlet: RouterOutlet;
  @ViewChild('canvas', {static: false}) canvas: FabricjsEditorComponent;

   a= ['hinh1.jpg','hinh2.jpg','hinh3.jpg']
  public saveSVG(){
    
    this.canvas.saveSVG()
  }
  public saveToGioHang(){
    
  }
  public gioHang(){
   
  }
  public rasterize() {
    this.canvas.rasterize();
  }
  public submit(){
    this.canvas.rasterizeJSON()
    this.canvas.url
    const formData = new FormData();
      formData.append('file', this.canvas.getBase64());
      formData.append('idElement',this.canvas.json)
      this.http.post('https://cozastores.azurewebsites.net/api/GetSanPhamThuongDeThietKes', formData)
      .subscribe(res => {
        this.serviceToast.showToastThemThanhCong()
        this.idflags = []
      },err=>{
        this.serviceToast.showToastThemThatBai()
        this.idflags = []
      });
  }
 
  deleteElement(element:string){
    console.log(this.canvas.url)
  }
  // public idf:string
  getURL(event:any){
    const el = event.target;
    this.url = el.src;  
 


    // return this.idflag.push(this.idf) 
    // let elementId: string = (event.target as Element).id;
    // console.log(elementId)
    // return this.idflags.push(elementId)
  }
  public addImage(event , id: number ){
    this.canvas.addImage(event);
     this.getURL(event)
    this.id = id 
    console.log(this.id)
  }
  public rasterizeSVG() {
    this.canvas.rasterizeSVG();
  }

  public saveCanvasToJSON() {
    this.canvas.saveCanvasToJSON();
  }

  public loadCanvasFromJSON() {
    this.canvas.loadCanvasFromJSON();
  }

  public confirmClear() {
    this.canvas.confirmClear();
  }

public getdsadas(){

}
  public changeSize() {
    this.canvas.changeSize();
  }

  public addText() {
    this.canvas.addText();
  }

  public getImgPolaroid(event) {
    this.canvas.getImgPolaroid(event);
  }

  public addImageOnCanvas(url) {
    this.canvas.addImageOnCanvas(url);
  }

  public readUrl(event) {
    this.canvas.readUrl(event);
  }

  public removeWhite(url) {
    this.canvas.removeWhite(url);
  }

  public addFigure(figure) {
    this.canvas.addFigure(figure);
  }

  public removeSelected(element) {
    this.canvas.removeSelected();
    this.deleteElement(element)
  }

  public sendToBack() {
    this.canvas.sendToBack();
  }

  public bringToFront() {
    this.canvas.bringToFront();
  }

  public clone() {
    this.canvas.clone();
  }

  public cleanSelect() {
    this.canvas.cleanSelect();
  }

  public setCanvasFill() {
    this.canvas.setCanvasFill();
  }

  public setCanvasImage() {
    this.canvas.setCanvasImage();
  }

  public setId() {
    this.canvas.setId();
  }

  public setOpacity() {
    this.canvas.setOpacity();
  }

  public setFill() {
    this.canvas.setFill();
  }

  public setFontFamily() {
    this.canvas.setFontFamily();
  }

  public setTextAlign(value) {
    this.canvas.setTextAlign(value);
  }

  public setBold() {
    this.canvas.setBold();
  }

  public setFontStyle() {
    this.canvas.setFontStyle();
  }

  public hasTextDecoration(value) {
    this.canvas.hasTextDecoration(value);
  }
  public aaa(event){
    this.canvas.aaa(event)
  }
  public setTextDecoration(value) {
    this.canvas.setTextDecoration(value);
  }

  public setFontSize() {
    this.canvas.setFontSize();
  }
  public dd(){
    var node = document.getElementById('my-node');

    htmlToImage.toPng(node)
  .then(function (dataUrl) {
    var img = new Image();
    img.src = dataUrl;
    document.body.appendChild(img);
  })
  .catch(function (error) {
    console.error('oops, something went wrong!', error);
  }); 
  }
  public setLineHeight() {
    this.canvas.setLineHeight();
  }

  public setCharSpacing() {
    this.canvas.setCharSpacing();
  }

  public rasterizeJSON() {
    this.canvas.rasterizeJSON();
  }
  b64toBlob = (b64Data, contentType='', sliceSize=512) => {
    const byteCharacters = atob(b64Data);
    const byteArrays = [];
  
    for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
      const slice = byteCharacters.slice(offset, offset + sliceSize);
  
      const byteNumbers = new Array(slice.length);
      for (let i = 0; i < slice.length; i++) {
        byteNumbers[i] = slice.charCodeAt(i);
      }
  
      const byteArray = new Uint8Array(byteNumbers);
      byteArrays.push(byteArray);
    }
  
    const blob = new Blob(byteArrays, {type: contentType});
    return blob;
  }
 contentType = 'image/png';
 //blob = this.b64toBlob(this.saveSVG.toString(), this.contentType);

 json;
  
  getId(id:number){
    return id
  }
}
export class asd{
  id: number
 dataHinhAnh:string

}