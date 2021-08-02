using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.ClientToServerModels;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Models;

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaGiamGiasController : ControllerBase
    {
        private readonly DPContext _context;
        public MaGiamGiasController(DPContext context)
        {
            this._context = context;
        }
        [HttpPost]
        public async Task<ActionResult> TaoMaGiamGia([FromForm] UploadMaGiamGia uploadMaGiamGia )
        {
            MaGiamGia maGiamGia = new MaGiamGia();
            maGiamGia.Code=RandomString(5);
            maGiamGia.SoTienGiam = uploadMaGiamGia.SoTienGiam;
            _context.Add(maGiamGia);
            await _context.SaveChangesAsync();
            return Ok();
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
