using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.Models;

namespace Web_API_e_Fashion.ClientToServerModels
{
    public class UploadPhieuNhapHang
    {

        public string NguoiLapPhieu { get; set; }
        public string GhiChu { get; set; }
        public decimal TongTien { get; set; }
        public string IdNhaCungCap { get; set; }

        public ICollection<UploadChiTietPhieuNhapHang> ChiTietPhieuNhaps { get; set; }
    }
}
