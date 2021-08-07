using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.ServerToClientModels
{
    public class SanPhamBienTheMauSize
    {
         public int Id { get; set; }
        public int? Id_SanPham { get; set; }
        public string TenMau { get; set; }
        public int? GioiTinh { get; set; }
        public int SoLuongTon { get; set; }
        public string TenSize { get; set; }

    }
}
