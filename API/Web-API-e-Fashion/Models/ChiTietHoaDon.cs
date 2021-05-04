using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int Id { get; set; }
        public int Soluong { get; set; }
       
        public decimal ThanhTien { get; set; }
        public int? HoaDonId { get; set; }

        public virtual HoaDon HoaDon { get; set; }
        public int? SanPhamId { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
