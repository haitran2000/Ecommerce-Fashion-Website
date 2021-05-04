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
        public SanPham()
        {
            this.BillInfos = new HashSet<ChiTietHoaDon>();
            this.GiaSanPhams = new HashSet<GiaSanPham>();
        }
        [Key]
        public int Id { get; set; }
        public string Ten { get; set; }
        public string ImagePath { get; set; }
        public int? KhuyenMai { get; set; }
        public string? MoTa { get; set; }
        public int? SoLuong { get; set; }
        public int? TrangThaiSanPham { get; set; }
      
        public int? KhoiLuong { get; set; }
        public string? HuongDan { get; set; }
        public string? MauSac { get; set; }
        public string? ThanhPhan { get; set; }
        public string? ChatLieu { get; set; }
        public int? CreateBy { get; set; }
        public int? UpdateBy { get; set; }
        public System.DateTime? CreatedDate { get; set; }
        public System.DateTime? UpdatedDate { get; set; }


        public bool? TrangThaiHoatDong { get; set; }       
        public virtual ICollection<ChiTietHoaDon> BillInfos { get; set; }
        public int? BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual ThuongHieu Brand { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Loai Category { get; set; }
        public virtual ICollection<GiaSanPham> GiaSanPhams { get; set; }
        public ICollection<SanPhamThietKe> SanPhamThietKes { get; set; }
        public List<SanPham_SanPhamThietKe> SanPham_SanPhamThietKes { get; set; }

        public virtual ICollection<ImageSanPham> ImageSanPhams { get; set; }
    }
}
