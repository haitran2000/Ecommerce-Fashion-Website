import { Product } from './product';

// Order
export interface Order {
    shippingDetails?: any;
    product?: Product;
    orderId?: any;
    totalAmount?: any;
}