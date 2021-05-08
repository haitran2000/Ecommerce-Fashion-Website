import { Component, OnInit } from '@angular/core';
import { ProductOneSlider } from '../../../shared/data/slider';
import { Product } from '../../../shared/classes/product';
import { ProductService } from '../../../shared/services/product.service';

@Component({
  selector: 'app-multi-slider',
  templateUrl: './multi-slider.component.html',
  styleUrls: ['./multi-slider.component.scss']
})
export class MultiSliderComponent implements OnInit {

  public products: Product[] = [];

  public ProductSliderOneConfig: any = ProductOneSlider;

  constructor(public productService: ProductService) { 
    this.productService.getProducts.subscribe(response => 
      this.products = response.filter(item => item.type == 'bags')
    );
  }

  ngOnInit(): void {
  }

}
