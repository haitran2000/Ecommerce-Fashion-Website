using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class SanPham_SanPhamThietKe
    {
        public int SanPhamId { get; set; }
        public int SanPhamThietKeId { get; set; }
        public System.DateTime PublicationDate { get; set; }

        public virtual SanPham SanPham { get; set; }
        public virtual SanPhamThietKe SanPhamThietKe { get; set; }
    }
}
