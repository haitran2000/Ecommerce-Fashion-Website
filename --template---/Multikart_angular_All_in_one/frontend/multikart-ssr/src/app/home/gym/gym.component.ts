import { Component, OnInit, OnDestroy } from '@angular/core';
import { Product } from '../../shared/classes/product';
import { ProductService } from '../../shared/services/product.service';
import { InstagramService } from '../../shared/services/instagram.service';

@Component({
  selector: 'app-gym',
  templateUrl: './gym.component.html',
  styleUrls: ['./gym.component.scss']
})
export class GymComponent implements OnInit, OnDestroy {

  public themeLogo: string = 'assets/images/icon/logo-2.png'; // Change Logo
  public products: Product[] = [];

  constructor(public productService: ProductService,
    private instaService: InstagramService) {
    this.productService.getProducts.subscribe(response => 
      this.products = response.filter(item => item.type == 'gym')
    );
  }

  public sliders = [{
    title: 'summer sale',
    subTitle: 'Protien Powder',
    image: 'assets/images/slider/19.jpg'
  }, {
    title: 'summer sale',
    subTitle: 'Protien Powder',
    image: 'assets/images/slider/20.jpg'
  }];
  
  // Blog
  public blogs = [{
    image: 'assets/images/blog/28.jpg',
    date: '25 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/29.jpg',
    date: '26 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/30.jpg',
    date: '27 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/31.jpg',
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
    document.documentElement.style.setProperty('--theme-deafult', '#3d72f1');
    document.documentElement.style.setProperty('--theme-gradient1', '#01effc');
    document.documentElement.style.setProperty('--theme-gradient2', '#485ff2');
  }

  ngOnDestroy(): void {
    // Remove Color
    document.documentElement.style.removeProperty('--theme-deafult');
    document.documentElement.style.removeProperty('--theme-gradient1');
    document.documentElement.style.removeProperty('--theme-gradient2');
  }

}
