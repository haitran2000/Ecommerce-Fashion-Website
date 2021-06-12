import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Product, ProductService } from '../product.service';

@Component({
  selector: 'app-productdetail',
  templateUrl: './productdetail.component.html',
  styleUrls: ['./productdetail.component.scss']
})
export class ProductdetailComponent implements OnInit {

  public product : Product
  constructor(public http : HttpClient,
              public router : Router,
              public service: ProductService
            ) { }

  ngOnInit(): void {
    this.http.get("https://localhost:5001/api/sanphams/"+this.service.product.id).subscribe(
      res=>{
        this.product = res as Product
        console.log(this.product)
      },
      error=>{
        
      }
    )
  }
}
