import { Component, OnInit, OnDestroy } from '@angular/core';
import { ProductSlider } from '../../shared/data/slider';
import { Product } from '../../shared/classes/product';
import { ProductService } from '../../shared/services/product.service';

@Component({
  selector: 'app-pets',
  templateUrl: './pets.component.html',
  styleUrls: ['./pets.component.scss']
})
export class PetsComponent implements OnInit, OnDestroy {

  public themeLogo: string = 'assets/images/icon/logo-13.png'; // Change Logo
  
  public products: Product[] = [];
  
  public ProductSliderConfig: any = ProductSlider;

  constructor(public productService: ProductService) {
    this.productService.getProducts.subscribe(response => {
      this.products = response.filter(item => item.type == 'pets');
    });
  }

  public sliders = [{
    title: 'every pet is different',
    subTitle: 'lets shop',
    image: 'assets/images/slider/17.jpg'
  }, {
    title: 'Any thing that pets want',
    subTitle: 'save 20%',
    image: 'assets/images/slider/18.jpg'
  }];

  // Logo
  public logos = [{
    image: 'assets/images/logos/9.png',
  }, {
    image: 'assets/images/logos/10.png',
  }, {
    image: 'assets/images/logos/11.png',
  }, {
    image: 'assets/images/logos/12.png',
  }, {
    image: 'assets/images/logos/13.png',
  }, {
    image: 'assets/images/logos/14.png',
  }, {
    image: 'assets/images/logos/15.png',
  }, {
    image: 'assets/images/logos/16.png',        
}]

  // Collection banner
  public collections1 = [{
    image: 'assets/images/collection/pets/1.jpg',
    title: 'Clothes'
  }, 
  {
    image: 'assets/images/collection/pets/2.jpg',
    title: 'Groom'
  },
  {
    image: 'assets/images/collection/pets/3.jpg',
    title: 'food'
  }];

  public collections2 = [{
    image: 'assets/images/collection/pets/4.jpg',
    title: 'Home'
  },
  {
    image: 'assets/images/collection/pets/5.jpg',
    title: 'cats'
  },
  {
    image: 'assets/images/collection/pets/6.jpg',
    title: 'bowls'
  }];

  // Blog
  public blogs = [{
    image: 'assets/images/blog/24.jpg',
    date: '25 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    details: 'Lorem ipsum dolor sit consectetur adipiscing elit,Lorem ipsum dolor sit consectetur adipiscing elit',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/25.jpg',
    date: '26 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    details: 'Lorem ipsum dolor sit consectetur adipiscing elit,Lorem ipsum dolor sit consectetur adipiscing elit',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/26.jpg',
    date: '27 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    details: 'Lorem ipsum dolor sit consectetur adipiscing elit,Lorem ipsum dolor sit consectetur adipiscing elit',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/27.jpg',
    date: '28 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    details: 'Lorem ipsum dolor sit consectetur adipiscing elit,Lorem ipsum dolor sit consectetur adipiscing elit',
    by: 'John Dio'
  }];

  ngOnInit(): void {
    // Change color for this layout
    document.documentElement.style.setProperty('--theme-deafult', '#ff9944');
  }

  ngOnDestroy(): void {
    // Remove Color
    document.documentElement.style.removeProperty('--theme-deafult');
  }

}
