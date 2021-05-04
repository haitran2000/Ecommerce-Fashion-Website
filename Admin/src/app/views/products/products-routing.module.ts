import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products.component';
import { ProductComponent } from './product/product.component';

const routes: Routes = [
  {
    path: '',
    component: ProductsComponent,
    data: {
      title: 'products'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes),],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
