import { Component, OnInit } from '@angular/core';
import { ProductSlider } from '../../../shared/data/slider';
import { Product } from '../../../shared/classes/product';
import { ProductService } from '../../../shared/services/product.service';

@Component({
  selector: 'app-product-slider',
  templateUrl: './product-slider.component.html',
  styleUrls: ['./product-slider.component.scss']
})
export class ProductSliderComponent implements OnInit {

  public products: Product[] = [];

  public ProductSliderConfig: any = ProductSlider;
  
  constructor(public productService: ProductService) { 
    this.productService.getProducts.subscribe(response => this.products = response);
  }

  ngOnInit(): void {
  }

}
