﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string TenSanPham { get; set; }
        public string TranType { get; set; }
    }
}
