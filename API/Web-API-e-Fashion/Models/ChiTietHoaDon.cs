using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int? Id_HoaDon { get; set; }
        [ForeignKey("Id_HoaDon")]
        public virtual HoaDon HoaDon { get; set; }
        public int? Id_SanPhamBienThe { get; set; }
        [ForeignKey("Id_SanPhamBienThe")]
        public virtual SanPhamBienThe SanPhamBienThe { get; set; }
    }
}
