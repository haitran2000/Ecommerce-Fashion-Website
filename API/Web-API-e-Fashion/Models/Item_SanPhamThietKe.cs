using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class Item_SanPhamThietKe
    {
      
        public int ItemId { get; set; }
     
        public virtual Item Item { get; set; }
        public int SanPhamThietKeId { get; set; }
    
        public virtual SanPhamThietKe SanPhamThietKe { get; set; }
        public System.DateTime PublicationDate { get; set; }

     
    }
}
