
import { CommonModule } from '@angular/common';
import { NotifierModule } from 'angular-notifier';
import { KonvaModule } from 'ng2-konva';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {NgxPaginationModule} from 'ngx-pagination';
import {MatTabsModule} from '@angular/material/tabs';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';

import { MatChipsModule } from '@angular/material/chips';
import { MatRippleModule } from '@angular/material/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';

import { MatInputModule } from '@angular/material/input';

import { MatSelectModule } from '@angular/material/select';
import {MatStepperModule} from '@angular/material/stepper';
import { MatSortModule } from '@angular/material/sort';

//



import { LayoutModule } from '@angular/cdk/layout';
import { NgModule,CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';
import {HttpClientModule} from '@angular/common/http'
import { IconModule, IconSetModule, IconSetService } from '@coreui/icons-angular';
const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true
};
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
// Import containers
import { DefaultLayoutComponent } from './containers';
import { P404Component } from './views/error/404.component';
import { P500Component } from './views/error/500.component';
import { LoginComponent } from './views/account/login/login.component';

import {MatDialogModule} from '@angular/material/dialog';
const APP_CONTAINERS = [
  DefaultLayoutComponent
];

import {
 
  AppAsideModule,
  AppBreadcrumbModule,
  AppHeaderModule,
  AppFooterModule,
  AppSidebarModule,
} from '@coreui/angular';

// Import routing module
import { AppRoutingModule } from './app.routing';

// Import 3rd party components
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';

import { OrdersTableComponent } from './orders-table/orders-table.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { RegistrationFormComponent } from './views/account/registration-form/registration-form.component';
import { UserService } from './views/account/user.service';
import { UserdetailComponent } from './containers/userdetail/userdetail.component';


import { BrandsComponent } from './views/brands/brands.component';
import { ColorPickerModule } from 'ngx-color-picker';

import { ItemSanPhamThietKeComponent } from './views/item-san-pham-thiet-ke/item-san-pham-thiet-ke.component';
import { ItemsComponent } from './views/items/items.component';
import { MauSacsComponent } from './views/mau-sacs/mau-sacs.component';

import { SanPhamThietKesComponent } from './views/san-pham-thiet-kes/san-pham-thiet-kes.component';
import { SizesComponent } from './views/sizes/sizes.component';
import { SanPhamSanPhamThietKeComponent } from './views/san-pham-san-pham-thiet-ke/san-pham-san-pham-thiet-ke.component';

import { CategoryService } from './views/categories/category.service';
import { CategoryComponent } from './views/categories/category/category.component';
import { ProductInCategoryComponent } from './views/categories/product-in-category/product-in-category.component';
import { HoaDonsComponent } from './views/hoa-dons/hoa-dons.component';
import { ChiTietHoaDonsComponent } from './views/chi-tiet-hoa-dons/chi-tiet-hoa-dons.component';
import { JobSeekesComponent } from './views/job-seekes/job-seekes.component';
import { AspNetUsersComponent } from './views/asp-net-users/asp-net-users.component';
import { AspNetUserClaimsComponent } from './views/asp-net-user-claims/asp-net-user-claims.component';
import { AspNetUserRolesComponent } from './views/asp-net-user-roles/asp-net-user-roles.component';
import { AspNetUserLoginsComponent } from './views/asp-net-user-logins/asp-net-user-logins.component';
import { AspNetUserTokensComponent } from './views/asp-net-user-tokens/asp-net-user-tokens.component';
import { AuthHistoriesComponent } from './views/auth-histories/auth-histories.component';
import { BrandComponent } from './views/brands/brand/brand.component';
import { ProductsComponent } from './views/products/products.component';
import { ProductComponent } from './views/products/product/product.component';
import { ImagesmodelComponent } from './views/products/imagesmodel/imagesmodel.component';
import { CategoriesComponent } from './views/categories/categories.component';
import { SizeComponent } from './views/sizes/size/size.component';
import { MauSacComponent } from './views/mau-sacs/mau-sac/mau-sac.component';

import { AuthGuard } from './views/auth.guard';
import { ModalComponent } from './modal/modal.component';
import { SanPhamBienTheComponent } from './views/gia-san-phams/san-pham-bien-the/san-pham-bien-thecomponent';
import { SanPhamBienThesComponent } from './views/gia-san-phams/san-pham-bien-thes.component';
import { ItemComponent } from './views/items/item/item.component';
import { ProfileComponent } from './views/account/profile/profile.component';

import { HoaDonComponent } from './views/hoa-dons/hoa-don/hoa-don.component';
import { ChiTietHoaDonComponent } from './views/chi-tiet-hoa-dons/chi-tiet-hoa-don/chi-tiet-hoa-don.component';
import { ChartsModule } from 'ng2-charts';
import { SanPhamThietKeComponent } from './views/san-pham-thiet-kes/san-pham-thiet-ke/san-pham-thiet-ke.component';
import { FabricjsEditorModule } from '../../projects/angular-editor-fabric-js/src/public-api';
import { ModaSaveComponent } from './views/san-pham-thiet-kes/san-pham-thiet-ke/moda-save/moda-save.component';
import { ToastrModule } from 'ngx-toastr';









@NgModule({
  imports: [
    KonvaModule,
    ChartsModule,
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AppAsideModule,
    AppBreadcrumbModule.forRoot(),
    AppFooterModule,
    AppHeaderModule,
    AppSidebarModule,
    NgxPaginationModule,
    PerfectScrollbarModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    FabricjsEditorModule,
    IconModule,
    IconSetModule.forRoot(),
    MatTableModule,
    MatPaginatorModule,
    FormsModule,
    ReactiveFormsModule ,
    MatDialogModule,
    MatExpansionModule,
    ColorPickerModule,
    ToastrModule.forRoot({
      timeOut:1000,
      progressBar:true,
      progressAnimation:'increasing'
    }
   
    ),
    BrowserAnimationsModule,
    //
    NotifierModule,
    CommonModule,
    MatDialogModule,
    MatTableModule,
    MatIconModule,
    MatButtonModule,
    MatSnackBarModule,
    MatTabsModule,
    MatFormFieldModule,
    MatInputModule ,
    MatPaginatorModule,
    MatSelectModule ,
    CKEditorModule,
    MatStepperModule,
    FormsModule,
    ReactiveFormsModule,
    MatSortModule,
  ],
  declarations: [
    AppComponent,
    ...APP_CONTAINERS,
    P404Component,
    P500Component,
    LoginComponent,

    OrdersTableComponent,
    UserdetailComponent,
    BrandsComponent,
    ItemSanPhamThietKeComponent,
    ItemsComponent,
    MauSacsComponent,
    MauSacComponent,
    SanPhamThietKesComponent,
    SizesComponent,
    SanPhamSanPhamThietKeComponent,
    CategoryComponent,
    ProductInCategoryComponent,
    HoaDonsComponent,
    ChiTietHoaDonsComponent,
    JobSeekesComponent,
    AspNetUsersComponent,
    AspNetUserClaimsComponent,
    AspNetUserRolesComponent,
    AspNetUserLoginsComponent,
    AspNetUserTokensComponent,
    AuthHistoriesComponent,
    BrandComponent,
    ProductsComponent,
    ProductComponent,
   RegistrationFormComponent,
   ImagesmodelComponent,
   CategoriesComponent,
   SizeComponent,
   MauSacComponent,
    SanPhamBienTheComponent,
    SanPhamBienThesComponent,
   ModalComponent,
   ItemComponent,
   ProfileComponent,

   HoaDonComponent,
     ChiTietHoaDonComponent,
     SanPhamThietKeComponent,
     ModaSaveComponent,
 
  ],
  providers: [
    IconSetService,
    UserService,
    [AuthGuard],
    LoginComponent,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
