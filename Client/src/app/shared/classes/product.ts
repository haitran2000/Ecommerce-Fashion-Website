// Products
export interface Product {
    Id?: number;
    Ten?: string;
    MoTa?: string;
    Gia?: string;
    KhuyenMai?: string;
    Tag?: string;
    HuongDan?: string;
    ThanhPhan?: string;
}

export interface Variants {
    variant_id?: number;
    id?: number;
    sku?: string;
    size?: string;
    color?: string;
    image_id?: number;
}

export interface Images {
    image_id?: number;
    id?: number;
    alt?: string;
    src?: string;
    variant_id?: any[];
}