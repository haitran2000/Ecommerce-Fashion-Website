using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class Loai
    {
        public Loai()
        {
            this.MauSacs = new HashSet<MauSac>();
            this.SanPhams = new HashSet<SanPham>();
            this.Sizes = new HashSet<Size>();
        }
        [Key]
        public int Id { get; set; }
        public string Ten { get; set; }
        public string ImagePath { get; set; }
        public System.DateTime? DateCreate { get; set; }
        public virtual ICollection<MauSac> MauSacs { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }
    }
}
