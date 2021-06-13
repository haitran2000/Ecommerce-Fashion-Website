import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Import Containers
import { DefaultLayoutComponent } from './containers';
import { RegistrationFormComponent } from './views/account/registration-form/registration-form.component';
import { AspNetUserClaimsComponent } from './views/asp-net-user-claims/asp-net-user-claims.component';
import { AspNetUserLoginsComponent } from './views/asp-net-user-logins/asp-net-user-logins.component';
import { AspNetUserRolesComponent } from './views/asp-net-user-roles/asp-net-user-roles.component';
import { AspNetUserTokensComponent } from './views/asp-net-user-tokens/asp-net-user-tokens.component';
import { AspNetUsersComponent } from './views/asp-net-users/asp-net-users.component';
import { AuthHistoriesComponent } from './views/auth-histories/auth-histories.component';
import { AuthGuard } from './views/auth.guard';
import { BrandsComponent } from './views/brands/brands.component';
import { CategoriesComponent } from './views/categories/categories.component';
import { ChiTietHoaDonsComponent } from './views/chi-tiet-hoa-dons/chi-tiet-hoa-dons.component';

import { P404Component } from './views/error/404.component';
import { P500Component } from './views/error/500.component';
import { SanPhamBienThesComponent } from './views/gia-san-phams/san-pham-bien-thes.component';

import { HoaDonsComponent } from './views/hoa-dons/hoa-dons.component';
import { ItemSanPhamThietKeComponent } from './views/item-san-pham-thiet-ke/item-san-pham-thiet-ke.component';
import { ItemsComponent } from './views/items/items.component';
import { JobSeekesComponent } from './views/job-seekes/job-seekes.component';
import { LoginComponent } from './views/account/login/login.component';
import { MauSacsComponent } from './views/mau-sacs/mau-sacs.component';
import { ProductsComponent } from './views/products/products.component';

import { SanPhamSanPhamThietKeComponent } from './views/san-pham-san-pham-thiet-ke/san-pham-san-pham-thiet-ke.component';
import { SanPhamThietKesComponent } from './views/san-pham-thiet-kes/san-pham-thiet-kes.component';
import { SizesComponent } from './views/sizes/sizes.component';
import { ProductdetailComponent } from './views/products/productdetail/productdetail.component';
import { ProductComponent } from './views/products/product/product.component';
import { HoaDonComponent } from './views/hoa-dons/hoa-don/hoa-don.component';

import { DashboardComponent } from './views/dashboard/dashboard.component';
import { ChartJSComponent } from './views/chartjs/chartjs.component';
import { SanPhamThietKeComponent } from './views/san-pham-thiet-kes/san-pham-thiet-ke/san-pham-thiet-ke.component';
import { UserdetailComponent } from './containers/userdetail/userdetail.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full',
  },
  
  {
    path: '404',
    component: P404Component,
    data: {
      title: 'Page 404'
    }
  },
  {
    path: '500',
    component: P500Component,
    data: {
      title: 'Page 500'
    }
  },
  {
    path: 'login',
    component: LoginComponent,
    data: {
      title: 'Login Page'
    }
  },
  {
    path: 'register',
    component: RegistrationFormComponent,
    data: {
      title: 'Register Page'
    }
  },

  {
    path: '',
    component: DefaultLayoutComponent, canActivate: [AuthGuard],
    data: {
      title: 'Home'
    },
    children: [
      {
        path: 'profile',
       component: UserdetailComponent,canActivate: [AuthGuard],
      },
      {
        path: 'dashboard',
       component: DashboardComponent,canActivate: [AuthGuard],
      },
      {
        path: 'chartjs',
       component: ChartJSComponent,canActivate: [AuthGuard],
      },
    
      {
        path: 'product/add',
      component: ProductComponent, canActivate: [AuthGuard],
      },
      {
        path: 'product/edit/:id',
        component: ProductComponent,canActivate: [AuthGuard],
      },
      {
        path:'product/detail/:id',
        component: ProductdetailComponent,canActivate: [AuthGuard],
      },
      {
        path: 'products',
        component: ProductsComponent,canActivate: [AuthGuard],
      },
      {
        path: 'categories',
        component: CategoriesComponent,canActivate: [AuthGuard],
      },
      {
        path: 'sanphambienthes',
        component: SanPhamBienThesComponent,canActivate: [AuthGuard],
      },
      {
        path: 'brands',
        component: BrandsComponent,canActivate: [AuthGuard],
      },
      {
        path: 'sanphamthietkes',
        component: SanPhamThietKesComponent,canActivate: [AuthGuard],
      },
      {
        path: 'sanphamthietke',
        component: SanPhamThietKeComponent,canActivate: [AuthGuard],
      },
      {
        path: 'sanpham_sanphamthietkes',
        component: SanPhamSanPhamThietKeComponent,canActivate: [AuthGuard],
      },
      {
        path: 'sizes',
        component: SizesComponent,canActivate: [AuthGuard],
      },
      {
        path: 'mausacs',
        component: MauSacsComponent,canActivate: [AuthGuard],
      },
      {
        path: 'items',
        component: ItemsComponent,canActivate: [AuthGuard],
      },
      {
        path: 'item_sanphamthietke',
        component: ItemSanPhamThietKeComponent,canActivate: [AuthGuard],
      },
      {
        path: 'jobseekes',
        component: JobSeekesComponent,canActivate: [AuthGuard],
      },
      {
        path: 'hoadons',
        component: HoaDonsComponent,canActivate: [AuthGuard],
      },
      {
        path: 'chitiethoadons',
        component: ChiTietHoaDonsComponent,canActivate: [AuthGuard],
      },
      {
        path: 'aspnetusertokens',
        component: AspNetUserTokensComponent,canActivate: [AuthGuard],
      },
      {
        path: 'authhistories',
        component: AuthHistoriesComponent,canActivate: [AuthGuard],
      },
      {
        path: 'aspnetusertokens',
        component: AspNetUserTokensComponent,canActivate: [AuthGuard],
      },
      {
        path: 'aspnetusers',
        component: AspNetUsersComponent,canActivate: [AuthGuard],
      },
      {
        path: 'aspnetuserroles',
        component: AspNetUserRolesComponent,canActivate: [AuthGuard],
      },
      {
        path: 'aspnetuserlogins',
        component: AspNetUserLoginsComponent,canActivate: [AuthGuard],
      },
      {
        path: 'aspnetusertokens',
        component: AspNetUserTokensComponent,canActivate: [AuthGuard],
      },
      {
        path: 'aspnetuserclaims',
        component: AspNetUserClaimsComponent,canActivate: [AuthGuard],
      },
      {
        path: 'sanpham_sanphamthietke',
        component: SanPhamSanPhamThietKeComponent,canActivate: [AuthGuard],
      },
      {
        path: 'hoadon/detail/:id',
        component: HoaDonComponent,canActivate: [AuthGuard],
      },
    ]
  },
  { path: '**', component: P404Component }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes,{ useHash: false }) ],
  exports: [ RouterModule]
})
export class AppRoutingModule {}
