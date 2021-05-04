using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class PostBlogModel
    {
        public string Name { get; set; }
        public IFormFile TileImage { get; set; }
    }
}
