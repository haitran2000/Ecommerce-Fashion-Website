import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

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

const routes: Routes = [
  { 
    path: 'theme/title', 
    component: TitleComponent 
  },
  { 
    path: 'theme/collection-banner', 
    component: CollectionBannerComponent 
  },
  { 
    path: 'theme/home-slider', 
    component: HomeSliderComponent 
  },
  { 
    path: 'theme/category', 
    component: CategoryComponent 
  },
  { 
    path: 'theme/services', 
    component: ServicesComponent 
  },
  { 
    path: 'product/slider', 
    component: ProductSliderComponent 
  },
  { 
    path: 'product/banners', 
    component: BannersComponent 
  },
  { 
    path: 'product/tabs', 
    component: ProductTabsComponent 
  },
  { 
    path: 'product/multi-slider', 
    component: MultiSliderComponent 
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ElementsRoutingModule { }
