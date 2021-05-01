using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class Item
    {
        public Item()
        {
         
        }
        [Key]
        public int Id { get; set; }
        public string HinhAnh { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreateBy { get; set; }
        public int TrangThai { get; set; }
        public ICollection<SanPhamThietKe> SanPhamThietKes { get; set; }
        public List<Item_SanPhamThietKe> Item_SanPhamThietKes { get; set; }
    }
}
