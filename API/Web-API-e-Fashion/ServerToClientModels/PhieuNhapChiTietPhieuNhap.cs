using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.Models;

namespace Web_API_e_Fashion.ServerToClientModels
{
    public class PhieuNhapChiTietPhieuNhap
    {
        public int Id { get; set; }
        public string SoChungTu { get; set; }
        public DateTime NgayTao { get; set; }
        public decimal TongTien { get; set; }
        public string GhiChu { get; set; }
        public string NguoiLapPhieu { get; set; }    
        public NhaCungCap NhaCungCap { get; set; }
        public List<TenSanPhamBienTheChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}
