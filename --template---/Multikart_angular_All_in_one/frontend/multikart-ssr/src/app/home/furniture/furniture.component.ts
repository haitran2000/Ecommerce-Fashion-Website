import { Component, OnInit, OnDestroy } from '@angular/core';
import { Product } from '../../shared/classes/product';
import { ProductService } from '../../shared/services/product.service';

@Component({
  selector: 'app-furniture',
  templateUrl: './furniture.component.html',
  styleUrls: ['./furniture.component.scss']
})
export class FurnitureComponent implements OnInit, OnDestroy {

  public themeLogo: string = 'assets/images/icon/logo-12.png'; // Change Logo

  public products: Product[] = [];
  public productCollections: any[] = [];

  constructor(public productService: ProductService) {
    this.productService.getProducts.subscribe(response => {
      this.products = response.filter(item => item.type == 'furniture');
      // Get Product Collection
      this.products.filter((item) => {
        item.collection.filter((collection) => {
          const index = this.productCollections.indexOf(collection);
          if (index === -1) this.productCollections.push(collection);
        })
      })
    });
  }

  public sliders = [{
    title: 'furniture sofa',
    subTitle: 'harmony sofa',
    image: 'assets/images/slider/12.jpg'
  }, {
    title: 'furniture sofa',
    subTitle: 'harmony sofa',
    image: 'assets/images/slider/13.jpg'
  }];

  // Collection banner
  public collections = [{
    image: 'assets/images/collection/furniture/1.jpg',
    save: 'save 50%',
    title: 'Sofa',
    link: '/home/left-sidebar/collection/furniture'
  }, {
    image: 'assets/images/collection/furniture/2.jpg',
    save: 'save 50%',
    title: 'Bean Bag',
    link: '/home/left-sidebar/collection/furniture'
  },{
    image: 'assets/images/collection/furniture/3.jpg',
    save: 'save 50%',
    title: 'Chair',
    link: '/home/left-sidebar/collection/furniture'
  }]

  // Blog
  public blogs = [{
    image: 'assets/images/blog/14.jpg',
    date: '25 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/15.jpg',
    date: '26 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/16.jpg',
    date: '27 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/14.jpg',
    date: '28 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }]

  ngOnInit(): void {
    // Change color for this layout
    document.documentElement.style.setProperty('--theme-deafult', '#d4b196');
  }

  ngOnDestroy(): void {
    // Remove Color
    document.documentElement.style.removeProperty('--theme-deafult');
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
