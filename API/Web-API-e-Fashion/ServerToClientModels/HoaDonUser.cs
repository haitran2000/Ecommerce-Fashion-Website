﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.Models;

namespace Web_API_e_Fashion.ServerToClientModels
{
    public class HoaDonUser
    {
        public string FullName { get; set; }
        public int Id { get; set; }
        public System.DateTime NgayTao { get; set; }
        public string GhiChu { get; set; } //ghi chu
        public int? TrangThai { get; set; } // VD : Đang lấy hàng, đã giao hàng
        public string LoaiThanhToan { get; set; } //VD: Tiền mặt, thanh toán online
        public string DaLayTien { get; set; } //VD: Rồi, chưa
        public decimal TongTien { get; set; }
    }
}
