import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { ElementsRoutingModule } from './elements-routing.module';

// Theme Elements
import { TitleComponent } from './theme/title/title.component';
import { CollectionBannerComponent } from './theme/collection-banner/collection-banner.component';
import { HomeSliderComponent } from './theme/home-slider/home-slider.component';
import { CategoryComponent } from './theme/category/category.component';
import { ServicesComponent } from './theme/services/services.component';
// Product Elements
import { ProductSliderComponent } from './product/product-slider/product-slider.component';
import { BannersComponent } from './product/banners/banners.component';
import { ProductTabsComponent } from './product/product-tabs/product-tabs.component';
import { MultiSliderComponent } from './product/multi-slider/multi-slider.component';

@NgModule({
  declarations: [
    TitleComponent,
    CollectionBannerComponent,
    HomeSliderComponent,
    CategoryComponent,
    ServicesComponent,
    ProductSliderComponent,
    BannersComponent,
    ProductTabsComponent,
    MultiSliderComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ElementsRoutingModule
  ]
})
export class ElementsModule { }
