import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './views/header/header.component';
import { FooterComponent } from './views/footer/footer.component';
import { CartComponent } from './views/cart/cart.component';
import { CheckoutComponent } from './views/checkout/checkout.component';
import { HomeComponent } from './views/home/home.component';
import { ProductComponent } from './views/product/product.component';
import { ThankyouComponent } from './views/thankyou/thankyou.component';
import { AppClientComponent } from './app-client.component';
import { ClientRoutingModule } from './client.routing';




@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    CartComponent,
    CheckoutComponent,
    HomeComponent,
    ProductComponent,
    ThankyouComponent,
    AppClientComponent,
   

  ],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    BrowserModule,
    ClientRoutingModule,

  ]
})
export class ClientModule { }
