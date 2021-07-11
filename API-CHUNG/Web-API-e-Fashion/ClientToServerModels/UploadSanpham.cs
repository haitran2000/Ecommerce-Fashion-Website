﻿using Microsoft.AspNetCore.Http;
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
        public decimal? KhuyenMai { get; set; }
        public string? MoTa { get; set; }
        public string? Tag { get; set; }
        public string? TrangThaiSanPham { get; set; }
        public string? TrangThaiHoatDong { get; set; }
        public decimal? Gia  { get; set; }
        public string? HuongDan { get; set; }
      
        public string? ThanhPhan { get; set; }
        public int? Id_NhanHieu { get; set; }
        public int? Id_Loai { get; set; }
        public ICollection<IFormFile>? files { get; set; }
    }
}