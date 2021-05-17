using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    [Table("NhanHieus")]
    public class NhanHieu
    {
        [Key]
        public int Id { get; set; }
        public string Ten { get; set; }
        public string ThongTin { get; set; }
        public string ImagePath { get; set; }
        public System.DateTime? DateCreate { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
