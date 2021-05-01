using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class User
    {
        public User()
        {
            this.Bills = new HashSet<HoaDon>();
        }
        [Key]
        public int Id { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string ImagePath { get; set; }
        public string TenDayDu { get; set; }
        public string DiaChiChiTiet { get; set; }
        public string Quan { get; set; }
        public string Tinh { get; set; }
        public string Nuoc { get; set; }
        public string email { get; set; }
        public string DienThoai { get; set; }
        public int TrangThai { get; set; }
        public string GhiChu { get; set; }
        public string Create_By { get; set; }
        public DateTime? Update_Date { get; set; }
        public string Update_By { get; set; }
        public DateTime? Create_Date { get; set; }
        public string token_reset_pass { get; set; }
        public virtual ICollection<HoaDon> Bills { get; set; }
    }
}
