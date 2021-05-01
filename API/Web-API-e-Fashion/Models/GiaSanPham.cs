using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class GiaSanPham
    {
        [Key]
        public int Id { get; set; }
        public int? IdSanPham { get; set; }
        public int? IDMau { get; set; }
        public string Gia { get; set; }
        public Nullable<int> IdSize { get; set; }

        public virtual MauSac MauSac { get; set; }
        public virtual SanPham SanPham { get; set; }
        public virtual Size Size { get; set; }
    }
}
