using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class GiaSanPham
    {
        [Key]
        public int Id { get; set; }
        public int? SanPhamId { get; set; }
        [ForeignKey("SanPhamId")]
        public virtual SanPham SanPham { get; set; }
        public string Gia { get; set; }
        public int? MauId { get; set; }
        [ForeignKey("MauId")]
        public virtual MauSac MauSac { get; set; }
        public int? SizeId { get; set; }
        [ForeignKey("SizeId")]
        public virtual Size Size { get; set; }
    }
}
