import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// Import Containers
import { DefaultLayoutComponent } from './admin/containers';
import { RegistrationFormComponent } from './admin/containers/views/account/registration-form/registration-form.component';
import { AspNetUserClaimsComponent } from './admin/containers/views/asp-net-user-claims/asp-net-user-claims.component';
import { AspNetUserLoginsComponent } from './admin/containers/views/asp-net-user-logins/asp-net-user-logins.component';
import { AspNetUserRolesComponent } from './admin/containers/views/asp-net-user-roles/asp-net-user-roles.component';
import { AspNetUserTokensComponent } from './admin/containers/views/asp-net-user-tokens/asp-net-user-tokens.component';
import { AspNetUsersComponent } from './admin/containers/views/asp-net-users/asp-net-users.component';
import { AuthHistoriesComponent } from './admin/containers/views/auth-histories/auth-histories.component';
import { AuthGuard } from './admin/containers/views/auth.guard';
import { BrandsComponent } from './admin/containers/views/brands/brands.component';
import { CategoriesComponent } from './admin/containers/views/categories/categories.component';
import { ChiTietHoaDonsComponent } from './admin/containers/views/chi-tiet-hoa-dons/chi-tiet-hoa-dons.component';

import { P404Component } from './admin/containers/views/error/404.component';
import { P500Component } from './admin/containers/views/error/500.component';
import { SanPhamBienThesComponent } from './admin/containers/views/gia-san-phams/san-pham-bien-thes.component';

import { HoaDonsComponent } from './admin/containers/views/hoa-dons/hoa-dons.component';
import { ItemSanPhamThietKeComponent } from './admin/containers/views/item-san-pham-thiet-ke/item-san-pham-thiet-ke.component';
import { ItemsComponent } from './admin/containers/views/items/items.component';
import { JobSeekesComponent } from './admin/containers/views/job-seekes/job-seekes.component';
import { LoginComponent } from './admin/containers/views/account/login/login.component';
import { MauSacsComponent } from './admin/containers/views/mau-sacs/mau-sacs.component';
import { ProductsComponent } from './admin/containers/views/products/products.component';

import { SanPhamSanPhamThietKeComponent } from './admin/containers/views/san-pham-san-pham-thiet-ke/san-pham-san-pham-thiet-ke.component';
import { SanPhamThietKesComponent } from './admin/containers/views/san-pham-thiet-kes/san-pham-thiet-kes.component';
import { SizesComponent } from './admin/containers/views/sizes/sizes.component';
import { ProductdetailComponent } from './admin/containers/views/products/productdetail/productdetail.component';
import { ProductComponent } from './admin/containers/views/products/product/product.component';
import { HoaDonComponent } from './admin/containers/views/hoa-dons/hoa-don/hoa-don.component';

import { DashboardComponent } from './admin/containers/views/dashboard/dashboard.component';
import { ChartJSComponent } from './admin/containers/views/chartjs/chartjs.component';
import { SanPhamThietKeComponent } from './admin/containers/views/san-pham-thiet-kes/san-pham-thiet-ke/san-pham-thiet-ke.component';
import { UserdetailComponent } from './admin/containers/userdetail/userdetail.component';
import { WidgetsComponent } from './admin/containers/views/widgets/widgets.component';

// import { DefaultLayoutClientComponent } from './client/containers/default-layout-client/default-layout-client.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full',
  },
  // {
  //   path:'client',
  //   component:DefaultLayoutClientComponent,
  // },
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
        path:'admin/widget',
        component:WidgetsComponent
      },
      {
        path: 'admin/profile',
       component: UserdetailComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/profile',
       component: UserdetailComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/dashboard',
       component: DashboardComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/chartjs',
       component: ChartJSComponent,canActivate: [AuthGuard],
      },
    
      {
        path: 'admin/product/add',
      component: ProductComponent, canActivate: [AuthGuard],
      },
      {
        path: 'admin/product/edit/:id',
        component: ProductComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/product/detail/:id',
        component: ProductdetailComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/products',
        component: ProductsComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/categories',
        component: CategoriesComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/sanphambienthes',
        component: SanPhamBienThesComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/brands',
        component: BrandsComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/sanphamthietkes',
        component: SanPhamThietKesComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/sanphamthietke',
        component: SanPhamThietKeComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/sanpham_sanphamthietkes',
        component: SanPhamSanPhamThietKeComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/sizes',
        component: SizesComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/mausacs',
        component: MauSacsComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/items',
        component: ItemsComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/item_sanphamthietke',
        component: ItemSanPhamThietKeComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/jobseekes',
        component: JobSeekesComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/hoadons',
        component: HoaDonsComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/chitiethoadons',
        component: ChiTietHoaDonsComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/aspnetusertokens',
        component: AspNetUserTokensComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/authhistories',
        component: AuthHistoriesComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/aspnetusertokens',
        component: AspNetUserTokensComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/aspnetusers',
        component: AspNetUsersComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/aspnetuserroles',
        component: AspNetUserRolesComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/aspnetuserlogins',
        component: AspNetUserLoginsComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/aspnetusertokens',
        component: AspNetUserTokensComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/aspnetuserclaims',
        component: AspNetUserClaimsComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/sanpham_sanphamthietke',
        component: SanPhamSanPhamThietKeComponent,canActivate: [AuthGuard],
      },
      {
        path: 'admin/hoadon/detail/:id',
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
