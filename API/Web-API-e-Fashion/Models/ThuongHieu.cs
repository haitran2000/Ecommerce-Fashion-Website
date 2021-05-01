﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class ThuongHieu
    {
        public ThuongHieu()
        {
            this.SanPhams = new HashSet<SanPham>();
        }
        [Key]
        public int Id { get; set; }
        public string Ten { get; set; }
        public string ImagePath { get; set; }
        public System.DateTime? DateCreate { get; set; }

      
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}