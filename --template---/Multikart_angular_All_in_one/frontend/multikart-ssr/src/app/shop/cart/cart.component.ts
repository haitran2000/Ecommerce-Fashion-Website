import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductService } from "../../shared/services/product.service";
import { Product } from "../../shared/classes/product";

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  public products: Product[] = [];

  constructor(public productService: ProductService) {
    this.productService.cartItems.subscribe(response => this.products = response);
  }

  ngOnInit(): void {
  }

  public get getTotal(): Observable<number> {
    return this.productService.cartTotalAmount();
  }

  // Increament
  increment(product, qty = 1) {
    this.productService.updateCartQuantity(product, qty);
  }

  // Decrement
  decrement(product, qty = -1) {
    this.productService.updateCartQuantity(product, qty);
  }

  public removeItem(product: any) {
    this.productService.removeCartItem(product);
  }

}
