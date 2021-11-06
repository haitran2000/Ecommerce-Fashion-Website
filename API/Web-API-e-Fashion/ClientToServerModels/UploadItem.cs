using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.UploadDataFormClientModels
{
    public class UploadItem
    {
        public int? TrangThai { get; set; }
        public IFormFile TileImage { get; set; }

    }
}
