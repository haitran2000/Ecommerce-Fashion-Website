﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class Size
    {
        public Size()
        {
            this.GiaSanPhams = new HashSet<GiaSanPham>();
        }
        [Key]
        public int Id { get; set; }
        public string Size1 { get; set; }
        public int? LoaiId { get; set; }
        [ForeignKey("LoaiId")]
        public virtual Loai Loai { get; set; }
     
        public virtual ICollection<GiaSanPham> GiaSanPhams { get; set; }
    }
}
