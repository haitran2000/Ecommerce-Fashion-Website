using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.ClientToServerModels
{
    public class UploadChiTietPhieuNhapHang
    {
        public int? SoluongNhap { get; set; }
        public decimal? ThanhTienNhap { get; set; }
        public int? Id_PhieuNhapHang { get; set; }
        public int? Id_SanPhamBienThe { get; set; }
    }
}
