using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class ImageSanPham
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }
        public int? SanPhamId { get; set; }
        [ForeignKey("SanPhamId")]
        public virtual SanPham sanPham { get; set; }
    }
}
