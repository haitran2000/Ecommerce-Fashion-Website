import { Component, OnInit, AfterViewInit} from '@angular/core';
import { ButtonsConfiguration, PlainGalleryConfiguration } from '../../../shared/data/portfolio';
import { Image, AdvancedLayout } from '@ks89/angular-modal-gallery';

@Component({
  selector: 'app-masonry-grid-two',
  templateUrl: './masonry-grid-two.component.html',
  styleUrls: ['./masonry-grid-two.component.scss']
})
export class MasonryGridTwoComponent implements OnInit, AfterViewInit  {

  public galleryFilter: string = 'all'
  public ButtonsConfig: any = ButtonsConfiguration;
  public GalleryConfig: any = PlainGalleryConfiguration;
  
  public Images;
  
  public AllImage = [
    new Image(1, { img: 'assets/images/portfolio/1.jpg' }),
    new Image(2, { img: 'assets/images/portfolio/2.jpg' }),
    new Image(3, { img: 'assets/images/portfolio/3.jpg' }),
    new Image(4, { img: 'assets/images/portfolio/4.jpg' }),
    new Image(5, { img: 'assets/images/portfolio/5.jpg' }),
    new Image(6, { img: 'assets/images/portfolio/6.jpg' }),
    new Image(7, { img: 'assets/images/portfolio/7.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/8.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/9.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/10.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/11.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/12.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/13.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/14.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/15.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/16.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/17.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/18.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/19.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/20.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/21.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/22.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/23.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/24.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/25.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/26.jpg' })
  ];

  public FashionImage = [
    new Image(1, { img: 'assets/images/portfolio/1.jpg' }),
    new Image(2, { img: 'assets/images/portfolio/2.jpg' }),
    new Image(3, { img: 'assets/images/portfolio/3.jpg' }),
    new Image(4, { img: 'assets/images/portfolio/4.jpg' }),
    new Image(5, { img: 'assets/images/portfolio/5.jpg' }),
    new Image(6, { img: 'assets/images/portfolio/6.jpg' }),
    new Image(7, { img: 'assets/images/portfolio/7.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/8.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/9.jpg' })
  ]
  
  public ShoesImages = [
    new Image(8, { img: 'assets/images/portfolio/14.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/15.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/16.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/17.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/18.jpg' })
  ]
  
  public WatchImages = [
    new Image(8, { img: 'assets/images/portfolio/21.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/22.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/23.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/24.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/25.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/26.jpg' })
  ]

  constructor() { }

  ngOnInit(): void {
    this.Images = this.AllImage
  }

  ngAfterViewInit(): void {
    setTimeout(function(){ 
        // vanilla JS
        var grid = document.querySelector('.isotopeContainer');
        new (<any>window).Isotope( grid, {
          // options...
          itemSelector: '.isotopeSelector'
        });
    }, 2000);
  }

  openImage(image) {
    const index: number = this.getCurrentIndexCustomLayout(image, this.Images);
    this.GalleryConfig = Object.assign({}, this.GalleryConfig, { 
        layout: new AdvancedLayout(index, true) 
    });
  }

  getCurrentIndexCustomLayout(image: Image, images: Image[]): number {
    return image ? images.indexOf(image) : -1;
  };

  filter(term) {
    
    if(term == 'all') {
      this.Images = this.AllImage
    } else if(term == 'fashion') {
      this.Images = this.FashionImage
    } else if(term == 'shoes') {
      this.Images = this.ShoesImages
    } else if(term == 'watch') {
      this.Images = this.WatchImages
    }

    this.galleryFilter = term

    // For isotop layout
    setTimeout(function(){ 
      // vanilla JS
      var grid = document.querySelector('.isotopeContainer');
      new (<any>window).Isotope( grid, { filter: '.'+term });
    }, 500);

  }

}
