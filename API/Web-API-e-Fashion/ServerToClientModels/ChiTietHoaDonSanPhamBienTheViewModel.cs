using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.ServerToClientModels
{
    public class ChiTietHoaDonSanPhamBienTheViewModel
    {
        public int IdCTHD { get; set; }
        public int SoLuong { get; set; }
        public string TenSanPham { get; set; }
        public string HinhAnh { get; set; }
  
        public decimal Gia { get; set; }
        public string DaLayTien { get; set; }//VD: chưa, rồi
        public string TrangThai { get; set; } // VD : Đang lấy hàng, đã giao hàng
        public string LoaiThanhToan { get; set; } //VD: Tiền mặt, thanh toán online
        public string TenMau { get; set; }
        public string TenSize { get; set; }
        public decimal ThanhTien { get; set; }
        public int Id_HoaDon { get; set; }
    }
}
