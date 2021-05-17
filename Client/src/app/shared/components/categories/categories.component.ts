import { Component, OnInit } from '@angular/core';
import { Product } from '../../classes/product';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss']
})
export class CategoriesComponent implements OnInit {

  public products: Product[] = [];
  public collapse: boolean = true;

  constructor(public productService: ProductService) { 
    this.productService.getProducts.subscribe(product => this.products = product);
  }

  ngOnInit(): void {
  }

  get filterbyCategory() {
    const category = [...new Set(this.products.map(product => product.type))]
    return category
  }

}
