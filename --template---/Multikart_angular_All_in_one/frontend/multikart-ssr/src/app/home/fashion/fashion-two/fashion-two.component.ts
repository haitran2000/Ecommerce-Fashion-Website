import { Component, OnInit } from '@angular/core';
import { HomeSlider } from '../../../shared/data/slider';
import { Product } from '../../../shared/classes/product';
import { ProductService } from '../../../shared/services/product.service';

@Component({
  selector: 'app-fashion-two',
  templateUrl: './fashion-two.component.html',
  styleUrls: ['./fashion-two.component.scss']
})
export class FashionTwoComponent implements OnInit {
  
  public themeLogo: string = 'assets/images/icon/logo-5.png'; // Change Logo

  public products : Product[] = [];
  public productCollections: any[] = [];

  constructor(public productService: ProductService) {
    this.productService.getProducts.subscribe(response => {
      this.products = response.filter(item => item.type == 'fashion');
      // Get Product Collection
      this.products.filter((item) => {
        item.collection.filter((collection) => {
          const index = this.productCollections.indexOf(collection);
          if (index === -1) this.productCollections.push(collection);
        })
      })
    });
  }

  public HomeSliderConfig: any = HomeSlider;

  public sliders = [{
    title: 'welcome to fashion',
    subTitle: 'Men fashion',
    image: 'assets/images/slider/3.jpg'
  }, {
    title: 'welcome to fashion',
    subTitle: 'Women fashion',
    image: 'assets/images/slider/4.jpg'
  }]

  // Collection banner
  public collections1 = [{
    image: 'assets/images/collection/fashion/3.jpg',
    save: 'save 30%',
    title: 'Women'
  }, {
    image: 'assets/images/collection/fashion/4.jpg',
    save: 'save 50%',
    title: 'Watch'
  }];

  public collections2 = [{
    image: 'assets/images/collection/fashion/5.jpg',
    save: 'save 30%',
    title: 'Sandle'
  }, {
    image: 'assets/images/collection/fashion/6.jpg',
    save: 'save 10%',
    title: 'Kids'
  }];

  ngOnInit(): void {
  }

  // Product Tab collection
  getCollectionProducts(collection) {
    return this.products.filter((item) => {
      if (item.collection.find(i => i === collection)) {
        return item
      }
    })
  }

}
