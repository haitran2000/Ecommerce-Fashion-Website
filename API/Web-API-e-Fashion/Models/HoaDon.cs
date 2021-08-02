using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class HoaDon
    {
        [Key]
        public int Id { get; set; }
        public System.DateTime NgayTao { get; set; }
        public string GhiChi { get; set; }
        public string TrangThai { get; set; } // VD : Đang lấy hàng, đã giao hàng
        public string LoaiThanhToan { get; set; } //VD: Tiền mặt, thanh toán online
        public decimal TongTien { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public string? Id_User { get; set; }
        [ForeignKey("Id_User")]
        public virtual AppUser User { get; set; }
    }
}
