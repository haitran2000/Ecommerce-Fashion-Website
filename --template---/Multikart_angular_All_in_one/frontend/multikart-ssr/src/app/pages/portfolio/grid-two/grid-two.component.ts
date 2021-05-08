import { Component, OnInit } from '@angular/core';
import { ButtonsConfiguration, PlainGalleryConfiguration } from '../../../shared/data/portfolio';
import { Image, AdvancedLayout } from '@ks89/angular-modal-gallery';

@Component({
  selector: 'app-grid-two',
  templateUrl: './grid-two.component.html',
  styleUrls: ['./grid-two.component.scss']
})
export class GridTwoComponent implements OnInit {

  public galleryFilter: string = 'all'
  public ButtonsConfig: any = ButtonsConfiguration;
  public GalleryConfig: any = PlainGalleryConfiguration;
  
  public Images;

  public AllImage = [
    new Image(1, { img: 'assets/images/portfolio/grid/1.jpg' }),
    new Image(2, { img: 'assets/images/portfolio/grid/2.jpg' }),
    new Image(3, { img: 'assets/images/portfolio/grid/3.jpg' }),
    new Image(4, { img: 'assets/images/portfolio/grid/4.jpg' }),
    new Image(5, { img: 'assets/images/portfolio/grid/5.jpg' }),
    new Image(6, { img: 'assets/images/portfolio/grid/6.jpg' }),
    new Image(7, { img: 'assets/images/portfolio/grid/7.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/grid/8.jpg' })
  ];

  public FashionImage = [
    new Image(1, { img: 'assets/images/portfolio/grid/1.jpg' })
  ]

  public BagImages = [
    new Image(3, { img: 'assets/images/portfolio/grid/3.jpg' }),
    new Image(4, { img: 'assets/images/portfolio/grid/4.jpg' }),
    new Image(7, { img: 'assets/images/portfolio/grid/7.jpg' }),
  ];
  
  public ShoesImages = [
    new Image(2, { img: 'assets/images/portfolio/grid/2.jpg' }),
    new Image(8, { img: 'assets/images/portfolio/grid/8.jpg' })
  ]
  
  public WatchImages = [
    new Image(5, { img: 'assets/images/portfolio/grid/5.jpg' }),
    new Image(6, { img: 'assets/images/portfolio/grid/6.jpg' })
  ]

  constructor() { }

  ngOnInit(): void {
    this.Images = this.AllImage
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
    } else if(term == 'bags') {
      this.Images = this.BagImages
    } else if(term == 'shoes') {
      this.Images = this.ShoesImages
    } else if(term == 'watch') {
      this.Images = this.WatchImages
    }

    this.galleryFilter = term
  }

}
