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
        public string GhiChu { get; set; } //ghi chu
        public int? TrangThai { get; set; }
        public int? TrangThaiThanhToan { get; set; }
        public string DaLayTien { get; set; } //VD: Rồi, chưa
        public decimal TongTien { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public string Tinh { get; set; }
        public string Huyen { get; set; }
        public string Xa { get; set; }
        public string DiaChi { get; set; }

        public string? Id_User { get; set; }
        [ForeignKey("Id_User")]
        public virtual AppUser User { get; set; }
    }
}
