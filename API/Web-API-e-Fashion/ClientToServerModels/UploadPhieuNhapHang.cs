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
        public int Id { get; set; }
        public string SoChungTu { get; set; }
        public DateTime NgayTao { get; set; }
        public decimal TongTien { get; set; }
        public string NguoiLapPhieu { get; set; }
        public int? Id_NhaCungCap { get; set; }
        [ForeignKey("Id_NhaCungCap")]
        public string TrangThaiPhieuNhap { get; set; }
        public string TrangThaiThanhToan { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
        public List<UploadChiTietPhieuNhapHang> ChiTietPhieuNhaps { get; set; }
    }
}
