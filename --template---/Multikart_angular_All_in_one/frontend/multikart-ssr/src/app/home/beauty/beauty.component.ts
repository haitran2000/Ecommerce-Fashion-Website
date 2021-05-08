import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { VideoModalComponent } from "../../shared/components/modal/video-modal/video-modal.component";
import { ProductSlider } from '../../shared/data/slider';
import { Product } from '../../shared/classes/product';
import { ProductService } from '../../shared/services/product.service';

@Component({
  selector: 'app-beauty',
  templateUrl: './beauty.component.html',
  styleUrls: ['./beauty.component.scss']
})
export class BeautyComponent implements OnInit, OnDestroy {

  public themeLogo: string = 'assets/images/icon/logo-7.png'; // Change Logo
  public products: Product[] = [];

  public ProductSliderConfig: any = ProductSlider;

  @ViewChild("videoModal") VideoModal: VideoModalComponent;

  constructor(public productService: ProductService) {
      this.productService.getProducts.subscribe(response => 
        this.products = response.filter(item => item.type == 'beauty')
      );
  }

  // Sliders
  public sliders = [{
    title: 'save upto 20%',
    subTitle: 'creative & decor',
    image: 'assets/images/slider/15.jpg'
  }, {
    title: 'save upto 10%',
    subTitle: 'pre-made & custom',
    image: 'assets/images/slider/16.jpg'
  }];

  // Blogs
  public blogs = [{
    image: 'assets/images/blog/20.jpg',
    date: '25 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/21.jpg',
    date: '26 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/22.jpg',
    date: '27 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }, {
    image: 'assets/images/blog/23.jpg',
    date: '28 January 2018',
    title: 'Lorem ipsum dolor sit consectetur adipiscing elit,',
    by: 'John Dio'
  }]

  ngOnInit(): void {
    // Change color for this layout
    document.documentElement.style.setProperty('--theme-deafult', '#f0b54d');
  }

  ngOnDestroy(): void {
    // Remove Color
    document.documentElement.style.removeProperty('--theme-deafult');
  }

}
