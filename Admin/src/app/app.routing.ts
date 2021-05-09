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
import { BrandsComponent } from './views/brands/brands.component';
import { CategoriesComponent } from './views/categories/categories.component';
import { ChiTietHoaDonsComponent } from './views/chi-tiet-hoa-dons/chi-tiet-hoa-dons.component';

import { P404Component } from './views/error/404.component';
import { P500Component } from './views/error/500.component';
import { HoaDonsComponent } from './views/hoa-dons/hoa-dons.component';
import { ItemSanPhamThietKeComponent } from './views/item-san-pham-thiet-ke/item-san-pham-thiet-ke.component';
import { ItemsComponent } from './views/items/items.component';
import { JobSeekesComponent } from './views/job-seekes/job-seekes.component';
import { LoginComponent } from './views/login/login.component';
import { MauSacsComponent } from './views/mau-sacs/mau-sacs.component';
import { ProductsComponent } from './views/products/products.component';
import { RegisterComponent } from './views/register/register.component';
import { SanPhamSanPhamThietKeComponent } from './views/san-pham-san-pham-thiet-ke/san-pham-san-pham-thiet-ke.component';
import { SanPhamThietKesComponent } from './views/san-pham-thiet-kes/san-pham-thiet-kes.component';
import { SizesComponent } from './views/sizes/sizes.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
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
    component: DefaultLayoutComponent,
    data: {
      title: 'Home'
    },
    children: [
      {
        path: 'base',
        loadChildren: () => import('./views/base/base.module').then(m => m.BaseModule)
      },
      {
        path: 'buttons',
        loadChildren: () => import('./views/buttons/buttons.module').then(m => m.ButtonsModule)
      },
      {
        path: 'charts',
        loadChildren: () => import('./views/chartjs/chartjs.module').then(m => m.ChartJSModule)
      },
     
      {
        path: 'dashboard',
        loadChildren: () => import('./views/dashboard/dashboard.module').then(m => m.DashboardModule)
      },
      {
        path: 'icons',
        loadChildren: () => import('./views/icons/icons.module').then(m => m.IconsModule)
      },
      {
        path: 'notifications',
        loadChildren: () => import('./views/notifications/notifications.module').then(m => m.NotificationsModule)
      },
      {
        path: 'theme',
        loadChildren: () => import('./views/theme/theme.module').then(m => m.ThemeModule)
      },
      {
        path: 'widgets',
        loadChildren: () => import('./views/widgets/widgets.module').then(m => m.WidgetsModule)
      },
      {
        path: 'product/add',
        loadChildren: () => import('./views/products/product/product.module').then(m => m.ProductModule)
      },
      {
        path: 'product/edit/:id',
        loadChildren: () => import('./views/products/product/product.module').then(m => m.ProductModule)
      },
      {
        path: 'products',
        component: ProductsComponent,
      },
      {
        path: 'categories',
        component: CategoriesComponent,
      },
      {
        path: 'brands',
        component: BrandsComponent,
      },
      {
        path: 'sanphamthietkes',
        component: SanPhamThietKesComponent,
      },
      {
        path: 'sanphamthietkes',
        component: SanPhamThietKesComponent,
      },
      {
        path: 'sanpham_sanphamthietkes',
        component: SanPhamSanPhamThietKeComponent,
      },
      {
        path: 'sizes',
        component: SizesComponent,
      },
      {
        path: 'mausacs',
        component: MauSacsComponent,
      },
      {
        path: 'items',
        component: ItemsComponent,
      },
      {
        path: 'item_sanphamthietke',
        component: ItemSanPhamThietKeComponent,
      },
      {
        path: 'jobseekes',
        component: JobSeekesComponent,
      },
      {
        path: 'hoadons',
        component: HoaDonsComponent,
      },
      {
        path: 'chitiethoadons',
        component: ChiTietHoaDonsComponent,
      },
      {
        path: 'aspnetusertokens',
        component: AspNetUserTokensComponent,
      },
      {
        path: 'authhistories',
        component: AuthHistoriesComponent,
      },
      {
        path: 'aspnetusertokens',
        component: AspNetUserTokensComponent,
      },
      {
        path: 'aspnetusers',
        component: AspNetUsersComponent,
      },
      {
        path: 'aspnetuserroles',
        component: AspNetUserRolesComponent,
      },
      {
        path: 'aspnetuserlogins',
        component: AspNetUserLoginsComponent,
      },
      {
        path: 'aspnetusertokens',
        component: AspNetUserTokensComponent,
      },
      {
        path: 'aspnetuserclaims',
        component: AspNetUserClaimsComponent,
      },
      {
        path: 'sanpham_sanphamthietke',
        component: SanPhamSanPhamThietKeComponent,
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
