import { Component, OnInit, OnDestroy } from '@angular/core';
import { ProductSlider } from '../../shared/data/slider';
import { Product } from '../../shared/classes/product';
import { ProductService } from '../../shared/services/product.service';

@Component({
  selector: 'app-marijuana',
  templateUrl: './marijuana.component.html',
  styleUrls: ['./marijuana.component.scss']
})
export class MarijuanaComponent implements OnInit, OnDestroy {

  public themeLogo: string = 'assets/images/icon/logo-3.png';
  public themeFooterLogo: string = 'assets/images/icon/logo-9.png';
  
  public products: Product[] = [];
  public productCollections: any[] = [];

  public ProductSliderConfig: any = ProductSlider;
  
  constructor(public productService: ProductService) {
    this.productService.getProducts.subscribe(response => {
      this.products = response.filter(item => item.type == 'marijuana');
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
    title: 'special offer',
    subTitle: 'Buy Marijuana',
    image: 'assets/images/slider/28.jpg'
  }, {
    title: 'special offer',
    subTitle: 'cannabis weed',
    image: 'assets/images/slider/29.jpg'
  }];

  // Collection banner
  public collections = [{
    image: 'assets/images/collection/marijuana/1.jpg',
    save: 'save 50%',
    title: 'oils',
    link: '/home/left-sidebar/collection/marijuana',
    class: 'p-left'
  }, {
    image: 'assets/images/collection/marijuana/2.jpg',
    save: 'save 20%',
    title: 'liquid',
    link: '/home/left-sidebar/collection/marijuana',
    class: 'p-right'
  }];

  // Blog
  public blogs = [{
    image: 'assets/images/blog/40.jpg',
    date: '25 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/41.jpg',
    date: '26 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/42.jpg',
    date: '27 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/40.jpg',
    date: '28 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }];

  // Logo
  public logos = [{
    image: 'assets/images/logos/1.png',
  }, {
    image: 'assets/images/logos/2.png',
  }, {
    image: 'assets/images/logos/3.png',
  }, {
    image: 'assets/images/logos/4.png',
  }, {
    image: 'assets/images/logos/5.png',
  }, {
    image: 'assets/images/logos/6.png',
  }, {
    image: 'assets/images/logos/7.png',
  }, {
    image: 'assets/images/logos/8.png',
  }];

  ngOnInit(): void {
    // Change color for this layout
    document.documentElement.style.setProperty('--theme-deafult', '#5d7227');
    document.documentElement.style.setProperty('--theme-gradient1', '#5d7227');
    document.documentElement.style.setProperty('--theme-gradient2', '#203f15');
  }

  ngOnDestroy(): void {
    // Remove Color
    document.documentElement.style.removeProperty('--theme-deafult');
    document.documentElement.style.removeProperty('--theme-gradient1');
    document.documentElement.style.removeProperty('--theme-gradient2');
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
