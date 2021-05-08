using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class HoaDon
    {
        public HoaDon()
        {
            this.BillInfos = new HashSet<ChiTietHoaDon>();
        }
        [Key]
        public int Id { get; set; }
     
        public System.DateTime NgayTao { get; set; }
        public string GhiChi { get; set; }
        public decimal TongTien { get; set; }

       
        public virtual ICollection<ChiTietHoaDon> BillInfos { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
    }
}
