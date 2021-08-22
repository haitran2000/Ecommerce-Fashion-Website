using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.Models;
namespace Web_API_e_Fashion.ServerToClientModels
{
    public class Review
    {
        public string tenUser { get; set; }
        public DateTime? NgayComment { get; set; }
        public string Content { get; set; }
    }
}
