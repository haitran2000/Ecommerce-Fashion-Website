using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.Models;

namespace Web_API_e_Fashion.ServerToClientModels
{
    public class MotHoaDon
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string DiaChi { get; set; }

        public string SDT { get; set; }

        public string Email { get; set; }

        public HoaDon hoaDon { get; set; }
        public List<NhieuChiTietHoaDon> chiTietHoaDons { get; set; }
    }
}
