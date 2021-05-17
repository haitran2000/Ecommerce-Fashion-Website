using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class SanPham
    {
        [Key]
        public int Id { get; set; }
        public string Ten { get; set; }
       
        public string? MoTa { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? Gia { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? KhuyenMai { get; set; }
        public string Tag { get; set; }
        public string? HuongDan { get; set; }
        public string? ThanhPhan { get; set; }  
        public System.DateTime? NgayCapNhat { get; set; }
        public System.DateTime? NgayTao { get; set; }
        public string? TrangThaiSanPham { get; set; }
        public string? TrangThaiSanPhamThietKe { get; set; }
        public string? TrangThaiHoatDong { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDon { get; set; }
        public int? Id_NhanHieu { get; set; }
        [ForeignKey("Id_NhanHieu")]
        public virtual NhanHieu NhanHieu { get; set; }
        public int? Id_Loai { get; set; }
        [ForeignKey("Id_Loai")]
        public virtual Loai Loai { get; set; }
        public virtual ICollection<SanPhamBienThe> SanPhamBienThes { get; set; }
        public ICollection<SanPhamThietKe> SanPhamThietKes { get; set; }
        public List<SanPham_SanPhamThietKe> SanPham_SanPhamThietKes { get; set; }

        
    }
}
