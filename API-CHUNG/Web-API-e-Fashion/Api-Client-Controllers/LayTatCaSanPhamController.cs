using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.ResModels;

namespace Web_API_e_Fashion.Api_Client_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LayTatCaSanPhamController : ControllerBase
    {
        private readonly DPContext _context;
        public LayTatCaSanPhamController(DPContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<SanPhamSanPhamBienThe>> GetAllAsync()
        {
            var kb = from s in _context.SanPhams
                     join spbt in _context.SanPhamBienThes
                     on s.Id equals spbt.Id_SanPham
                     select new SanPhamSanPhamBienThe()
                     {
                         IdSP = spbt.Id,
                         Gia = (decimal)s.Gia,
                         //Hinh = spbt.ImagePath,
                         Name = s.Ten,

                     };
            return  kb.ToList();
        }
    }
}
