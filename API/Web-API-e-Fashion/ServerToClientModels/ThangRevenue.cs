using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.ServerToClientModels
{
    public class ThangRevenue
    {
        public string  Month { get; set; }
        public decimal Revenues { get; set; }
        public List<NgayRevenue> ListNgayRevenues { get; set; }

    }
}
