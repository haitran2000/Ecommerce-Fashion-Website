import { Component, OnInit, OnDestroy } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { HomeSlider, ProductSlider } from '../../shared/data/slider';
import { Product } from '../../shared/classes/product';
import { ProductService } from '../../shared/services/product.service';

@Component({
  selector: 'app-tools',
  templateUrl: './tools.component.html',
  styleUrls: ['./tools.component.scss']
})
export class ToolsComponent implements OnInit, OnDestroy {

  public themeLogo: string = 'assets/images/icon/logo-5.png';
  
  public products: Product[] = [];
  public productCollections: any[] = [];

  constructor(private _sanitizer:DomSanitizer,
    public productService: ProductService) {
    this.productService.getProducts.subscribe(response => {
      this.products = response.filter(item => item.type == 'tools');
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
  public ProductSliderConfig: any = ProductSlider;

  // services
  public categories = [{
    image: 'assets/images/categories/6.jpg',
    title: 'auto parts',
    text:  this._sanitizer.bypassSecurityTrustHtml('<li><a href="#">Shock-resistant parts</a></li><li><a href="#">Skeleton parts</a></li><li><a href="#">Slow parts</a></li><li><a href="#">Solar-powered parts</a></li>'),
  }, {
    image: 'assets/images/categories/7.jpg',
    title: 'brakes & steering',
    text:  this._sanitizer.bypassSecurityTrustHtml('<li><a href="#">Shock-resistant parts</a></li><li><a href="#">Skeleton parts</a></li><li><a href="#">Slow parts</a></li><li><a href="#">Solar-powered parts</a></li>'),
  }, {
    image: 'assets/images/categories/8.jpg',
    title: 'engine & drivetrain',
    text:  this._sanitizer.bypassSecurityTrustHtml('<li><a href="#">Shock-resistant parts</a></li><li><a href="#">Skeleton parts</a></li><li><a href="#">Slow parts</a></li><li><a href="#">Solar-powered parts</a></li>'),
  }, {
    image: 'assets/images/categories/9.jpg',
    title: 'exterior accesories',
    text:  this._sanitizer.bypassSecurityTrustHtml('<li><a href="#">Shock-resistant parts</a></li><li><a href="#">Skeleton parts</a></li><li><a href="#">Slow parts</a></li><li><a href="#">Solar-powered parts</a></li>'),
  }, {
    image: 'assets/images/categories/10.jpg',
    title: 'other parts',
    text:  this._sanitizer.bypassSecurityTrustHtml('<li><a href="#">Shock-resistant parts</a></li><li><a href="#">Skeleton parts</a></li><li><a href="#">Slow parts</a></li><li><a href="#">Solar-powered parts</a></li>'),
  }]

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
    // Add class in body
    document.body.classList.add("tools-bg");
  }

  ngOnDestroy(): void {
    // Remove class in body
    document.body.classList.remove("tools-bg");
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
