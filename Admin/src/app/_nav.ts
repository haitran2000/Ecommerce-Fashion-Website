import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Tổng quan',
    url: '/dashboard',
    icon: 'icon-speedometer',
    badge: {
      variant: 'info',
      text: 'NEW'
    }
  },
  {
    name: 'DS sản phẩm',
    url: '/products',
  
  },
  {
    name: 'DS loại',
    url: '/categories',
  
  },
  {
    name: 'DS nhãn hiệu',
    url: '/brands',
  
  },
  {
  name:'Sản phẩm thiết kế',
  url:'/sanphamthietke'
  },
  {
    name: 'DS sản phẩm thiết kế',
    url: '/sanphamthietkes',
  
  },
  {
    name: 'DS size',
    url: '/sizes',
  
  },
  {
    name: 'DS màu sắc',
    url: '/mausacs',
  
  },
  {
    name: 'DS sản phẩm biến thể',
    url: '/sanphambienthes',
  
  },
  {
    name: 'DS item',
    url: '/items',
  },
  {
    name: 'DS item Sản phẩm thiết kế',
    url: '/item_sanphamthietke',
  
  },
  {
    name: 'DS SP Sản phẩm thiết kế',
    url: '/sanpham_sanphamthietkes',
  
  },
  {
    name: 'DS chi tiết hóa đơn',
    url: '/chitiethoadons',
  },
  {
    name: 'DS hóa đơn',
    url: '/hoadons',
  },
  {
    name: 'JobSeekes',
    url: '/jobseekes',
  },
  {
    name: 'AspNetUsers',
    url: '/aspnetusers',
  
  },
  {
    name: 'AspNetUserClaims',
    url: '/aspnetuserclaims',
  
  },
  {
    name: 'AspNetUserRoles',
    url: '/aspnetuserroles',
  },
  {
    name: 'AspNetUserLogins',
    url: '/aspnetuserlogins',
  
  },
  {
    name: 'AspNetUserTokens',
    url: '/aspnetusertokens',
  
  },
  {
    name: 'AuthHistories',
    url: '/authhistories',
  
  },
];
