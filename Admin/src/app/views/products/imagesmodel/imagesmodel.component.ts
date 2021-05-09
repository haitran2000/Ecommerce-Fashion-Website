import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-imagesmodel',
  templateUrl: './imagesmodel.component.html',
  styleUrls: ['./imagesmodel.component.scss']
})
export class ImagesmodelComponent implements OnInit {

  constructor(public http : HttpClient,
            public service : ProductService) { }
  public imageproductList : ImageProduct[]
  ngOnInit(): void {
    this.http.get("https://localhost:44302/api/ImageSanPhams/"+this.service.product.id).subscribe(
      res=>{
        this.imageproductList = res as ImageProduct[]
        console.log( this.imageproductList)
        console.log( this.service.product.id)
      },
      error=>{
      }
    )
  }
}
export class ImageProduct{
  imagePath : string
  SanPhamId : number
}