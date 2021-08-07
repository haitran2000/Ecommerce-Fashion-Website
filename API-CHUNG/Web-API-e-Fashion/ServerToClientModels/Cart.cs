using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.Models;
namespace Web_API_e_Fashion.ServerToClientModels
{
    public class Cart
    {
        public int CartID { get; set; }

        public string UserID { get; set; }
        public string Mau { get; set; }
        public int SoLuong { get; set; }
        public string Size { get; set; }
        public ProductDetail ProductDetail { get; set; }
    }
}
