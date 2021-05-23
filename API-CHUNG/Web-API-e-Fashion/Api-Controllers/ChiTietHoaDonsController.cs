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
    public class ChiTietHoaDonsController : ControllerBase
    {
        private readonly DPContext _context;
        public ChiTietHoaDonsController(DPContext context)
        {
            this._context = context;
        }
        public async Task<ActionResult<IEnumerable<ChiTietHoaDon>>> ChiTetHoaDons()
        {
            return await _context.ChiTietHoaDons.ToListAsync();
        }
    }
}
