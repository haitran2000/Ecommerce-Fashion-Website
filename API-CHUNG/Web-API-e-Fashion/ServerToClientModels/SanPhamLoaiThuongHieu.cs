using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.ResModels
{
    public class SanPhamLoaiThuongHieu
    {
        public int Id { get; set; }
        public string? Ten { get; set; }
        public decimal? KhuyenMai { get; set; }
        public string? MoTa { get; set; }
        public string? Tag { get; set; }
        public string? Image { get; set; }
        public decimal? Gia { get; set; }
        public decimal? GiaNhap { get; set; }
        public string? TrangThaiSanPham { get; set; }
        public string? TrangThaiSanPhamThietKe { get; set; }
        public string? TrangThaiHoatDong { get; set; }
        public string? HuongDan { get; set; }
        public string? ThanhPhan { get; set; }
        public int? UpdateBy { get; set; }
        public int? Id_NhanHieu { get; set; }
        public int? Id_Loai { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? GiaSanPhams { get; set; }
        public int? SanPhamThietKes { get; set; }
        public int? SanPham_SanPhamThietKes { get; set; }

        public string TenLoai{ get; set; }
        public string TenNhanHieu { get; set; }

    }
}
