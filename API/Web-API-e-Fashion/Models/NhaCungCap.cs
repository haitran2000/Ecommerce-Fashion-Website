using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class NhaCungCap
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
