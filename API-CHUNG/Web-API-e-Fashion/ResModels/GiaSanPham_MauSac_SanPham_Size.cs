﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.ResModels
{
    public class GiaSanPham_MauSac_SanPham_Size
    {
        public string ImagePath { get; set; }
        public int Id { get; set; }
        public string MaMau { get; set; }
        public string TenSanPham { get; set; }
        public string TenSize { get; set; }
    }
}
