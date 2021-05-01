using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class MauSac
    {
        public MauSac()
        {
            this.GiaSanPhams = new HashSet<GiaSanPham>();
        }
        [Key]
        public int Id { get; set; }
        public string MaMau { get; set; }
        public int? IdLoai { get; set; }

        public virtual Loai Category { get; set; }
  
        public virtual ICollection<GiaSanPham> GiaSanPhams { get; set; }
    }
}
