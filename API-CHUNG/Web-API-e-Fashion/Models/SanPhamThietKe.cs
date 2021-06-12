
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class SanPhamThietKe
    {
        [Key]
        public int Id { get; set; }
        public long Gia { get; set; }
        public string HinhAnh { get; set; }
        public string DataHinhAnh { get; set; }
        public System.DateTime? CreatedDate { get; set; }
        public System.DateTime? UpdatedDate { get; set; }
        public int? CreateBy { get; set; }
        public int? UpdateBy { get; set; }
        public bool TrangThaiXacNhan { get; set; }
        public bool TrangThaiSanPham { get; set; }

        public ICollection<SanPham> SanPhams { get; set; }
        public ICollection<Item> Items { get; set; }
        public List<Item_SanPhamThietKe> Item_SanPhamThietKes { get; set; }
        public List<SanPham_SanPhamThietKe> SanPham_SanPhamThietKes { get; set; }
    }
}
