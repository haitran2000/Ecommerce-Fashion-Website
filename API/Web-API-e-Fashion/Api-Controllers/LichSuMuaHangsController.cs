using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Models;

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LichSuMuaHangsController : ControllerBase
    {
        private readonly DPContext _context;
        public LichSuMuaHangsController(DPContext context)
        {
            this._context = context;
        }
        [HttpGet("lichsumuahang")]
        public async Task<ActionResult<IEnumerable<HoaDon>>> GetLichSuMuaHang(string IdUser)
        {
            
            return await _context.HoaDons.Where(d => d.Id_User == IdUser).ToListAsync();
        }

    }
}
