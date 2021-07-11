import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Tổng quan',
    url: '/admin/dashboard',
    icon: 'icon-speedometer',
    badge: {
      variant: 'info',
      text: 'NEW'
    }
  },
  {
    name: 'DS sản phẩm',
    url: '/admin/products',
  },
  {
    name: 'DS loại',
    url: '/admin/categories',
  
  },
  {
    name: 'DS nhãn hiệu',
    url: '/admin/brands',
  
  },
  {
    name: 'DS size',
    url: '/admin/sizes',
  
  },
  {
    name: 'DS màu sắc',
    url: '/admin/mausacs',
  
  },
  {
    name: 'DS sản phẩm biến thể',
    url: '/admin/sanphambienthes',
  
  },
  {
    name: 'DS chi tiết hóa đơn',
    url: '/admin/chitiethoadons',
  },
  {
    name: 'DS hóa đơn',
    url: '/admin/hoadons',
  },
  {
    name:'DS User',
    url:'/admin/aspnetusers',
  }
];
