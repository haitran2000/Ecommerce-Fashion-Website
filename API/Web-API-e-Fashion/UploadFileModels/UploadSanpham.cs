using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.UploadFileModels
{
    public class UploadSanpham
    {
        public int Id { get; set; } 
        public string? Ten { get; set; }
        public int? KhuyenMai { get; set; }
        public string? MoTa { get; set; }
        public int? SoLuong { get; set; }
        public bool? TrangThaiSanPham { get; set; }
        public int? KhoiLuong { get; set; }
        public string? HuongDan { get; set; }
        public string? MauSac { get; set; }
        public string? ThanhPhan { get; set; }
        public string? ChatLieu { get; set; }
        public int? CreateBy { get; set; }
        public string? CreatedDate { get; set; }
        public int? UpdateBy { get; set; }
        public bool? TrangThaiHoatDong { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public List<IFormFile>? ListImage { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? GiaSanPhams { get; set; }
        public int? SanPhamThietKes { get; set; }
        public int? SanPham_SanPhamThietKes { get; set; }


    }
}
