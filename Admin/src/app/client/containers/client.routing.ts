import { NgModule } from '@angular/core';
import {  RouterModule, Routes } from '@angular/router';
import { ProductComponent } from '../../admin/containers/views/products/product/product.component';
import { CartComponent } from './views/cart/cart.component';
import { CheckoutComponent } from './views/checkout/checkout.component';
import { HomeComponent } from './views/home/home.component';
import { ThankyouComponent } from './views/thankyou/thankyou.component';

const routes:Routes=[
  {
      // path: '',
      // redirectTo: 'home',
      // pathMatch: 'full',
   },
  {
    path:'home',
    component:HomeComponent,
  },
  {
    path:'product/:id',
    component:ProductComponent,
  },{
    path:'cart',
    component:CartComponent
  },
  {
    path:'checkout',
    component:CheckoutComponent,
  },
  {
    path:'thanhyou',
    component:ThankyouComponent,
  }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)

  ],
  exports:[RouterModule]
})
export class ClientRoutingModule { }
