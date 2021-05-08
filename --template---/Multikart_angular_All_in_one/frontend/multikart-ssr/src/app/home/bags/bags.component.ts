import { Component, OnInit, OnDestroy } from '@angular/core';
import { ProductSlider, ProductOneSlider } from '../../shared/data/slider';
import { Product } from '../../shared/classes/product';
import { ProductService } from '../../shared/services/product.service';

@Component({
  selector: 'app-bags',
  templateUrl: './bags.component.html',
  styleUrls: ['./bags.component.scss']
})
export class BagsComponent implements OnInit, OnDestroy {

  public themeLogo: string = 'assets/images/icon/logo-7.png'; // Change Logo
  public themeLogoWhite: string = 'assets/images/icon/logo-8.png'; // Change Logo
  
  public products: Product[] = [];
  public productCollections: any[] = [];

  public ProductSliderConfig: any = ProductSlider;
  public ProductSliderOneConfig: any = ProductOneSlider;

  constructor(public productService: ProductService) {
    this.productService.getProducts.subscribe(response => {
      this.products = response.filter(item => item.type == 'bags');
      // Get Product Collection
      this.products.filter((item) => {
        item.collection.filter((collection) => {
          const index = this.productCollections.indexOf(collection);
          if (index === -1) this.productCollections.push(collection);
        })
      })
    });
  }
  
  // Sliders
  public sliders = [{
    title: 'summer sale',
    subTitle: 'the bag',
    image: 'assets/images/slider/25.jpg'
  }, {
    title: 'summer sale',
    subTitle: 'the bag',
    image: 'assets/images/slider/26.jpg'
  }, {
    title: 'summer sale',
    subTitle: 'the bag',
    image: 'assets/images/slider/27.jpg'
  }];

  // Categories
  public categories = ['airbag', 'burn bag', 'briefcase', 'carpet', 'money bag', 'tucker'];

  // Blog
  public blogs = [{
    image: 'assets/images/blog/37.jpg',
    date: '25 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/38.jpg',
    date: '26 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/39.jpg',
    date: '27 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/37.jpg',
    date: '28 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }];

  ngOnInit(): void {
    // Change color for this layout
    document.documentElement.style.setProperty('--theme-deafult', '#f0b54d');
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
