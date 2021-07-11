using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.ServerToClientModels
{
    public class SanPhamBienThe
    {
        public int Id { get; set; }
        public int? Id_SanPham { get; set; }
        public int? Id_Mau { get; set; }
        public int? SizeId { get; set; }
    }
}
