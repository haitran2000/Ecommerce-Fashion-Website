using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class SanPhamLike
    {
        public int id { get; set; }
        public int idSanPham { get; set; }
        public string ten { get; set; }
        public decimal gia { get; set; }
    }
}
