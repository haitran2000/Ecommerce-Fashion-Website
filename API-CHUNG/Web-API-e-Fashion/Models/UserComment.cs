﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class UserComment
    {
        public int IdAppUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual AppUser User { get; set; }

        public int IdSanPham { get; set; }
        [ForeignKey("IdSanPham")]
        public virtual SanPham SanPham { get; set; }
        public string Content { get; set; }
    }
}