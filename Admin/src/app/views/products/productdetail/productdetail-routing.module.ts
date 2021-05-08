import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes } from '@angular/router';
import { ProductdetailComponent } from './productdetail.component';

const routes: Routes = [
  {
    path: '',
    component: ProductdetailComponent,
    data: {
      title: 'productdetail'
    },
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class ProductdetailRoutingModule { }
