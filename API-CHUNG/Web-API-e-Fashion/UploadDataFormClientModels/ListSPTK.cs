using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.Models;

namespace Web_API_e_Fashion.UploadDataFormClientModels
{
    public class ListSPTK
    {
        public IList<SanPham> ListSP { get; set; }
        public IList<Item> ListItem { get; set; }

    }
}
