import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Biểu đồ tổng quan',
    url: '/admin/dashboard',
    icon: 'cil-chart-line',
  },
  {
    name: 'Biểu đồ shop',
    url: '/admin/chartsecond',
    icon: 'cil-chart',
  },
  {
    name: 'DS sản phẩm',
    url: '/admin/products',
    icon: 'cil-3d',
  },
  {
    name: 'DS loại',
    url: '/admin/categories',
    icon: 'cil-aperture',
  },
  {
    name: 'DS nhà cung cấp',
    url: '/admin/nhacungcaps',
    icon: 'cil-puzzle',
  },
  {
    name: 'DS nhãn hiệu',
    url: '/admin/brands',
    icon: 'cil-apps',
  },
  {
    name: 'DS size',
    url: '/admin/sizes',
    icon: 'cil-resize-width',
  },
  {
    name: 'DS màu sắc',
    url: '/admin/mausacs',
    icon: 'cil-burn',
  },
  {
    name: 'DS sản phẩm biến thể',
    url: '/admin/sanphambienthes',
    icon:'cil-dialpad'
  },
  {
    name: 'DS mã giảm giá',
    url: '/admin/magiamgias',
    icon: 'cil-puzzle',
  },
  {
    name: 'DS hóa đơn',
    url: '/admin/hoadons',   
    icon:'cil-notes'
  },
  {
    name:'DS User',
    url:'/admin/aspnetusers',
    icon:'cil-address-book'
  },
  {
    name:'Tạo phiếu nhập kho',
    url:'admin/taophieunhap',
    icon:'cil-address-book'
  }
];
