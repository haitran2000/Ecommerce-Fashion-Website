import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product.component';


const routes: Routes = [
  {
    path: '',
    component: ProductComponent,
    data: {
      title: 'add-or-edit-product'
    },
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes),],
  exports: [RouterModule]
})
export class ProductRoutingModule { }
