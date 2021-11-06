using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.ClientToServerModels;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Models;
using Web_API_e_Fashion.SignalRModels;

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaGiamGiasController : ControllerBase
    {
        private readonly DPContext _context;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        public MaGiamGiasController(DPContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            this._hubContext = hubContext;
            this._context = context;
            this._serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaGiamGia>>> GetMaGiamGias()
        {
          
            return await _context.MaGiamGias.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> TaoMaGiamGia([FromForm] UploadMaGiamGia uploadMaGiamGia )
        {
            MaGiamGia maGiamGia = new MaGiamGia();
            maGiamGia.Code=RandomString(5);
            maGiamGia.SoPhanTramGiam = uploadMaGiamGia.SoTienGiam;
            _context.Add(maGiamGia);

          
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> SuaMaGiamGia([FromForm] UploadMaGiamGia uploadMaGiamGia,int id)
        {
            MaGiamGia maGiamGia;
            maGiamGia = await _context.MaGiamGias.FindAsync(id);
            maGiamGia.Code = RandomString(5);
            maGiamGia.SoPhanTramGiam = uploadMaGiamGia.SoTienGiam;
            _context.Update(maGiamGia);
         
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMaGiamGias(int id)
        {
            MaGiamGia mgg;
            mgg = await _context.MaGiamGias.FindAsync(id);
            _context.MaGiamGias.Remove(mgg);
            await _hubContext.Clients.All.BroadcastMessage();
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("nhapmagiamgia")]
        public async Task<ActionResult> NhapMaGiamGia(UploadSanPhamGiamGia upload)
        {

            var product = await _context.SanPhams.FindAsync(upload.Id);
            var list = await _context.MaGiamGias.ToListAsync();

            //var product = _context.SanPhams.Find(upload.Id);
            //var list = _context.MaGiamGias.ToList();
            foreach (MaGiamGia mgg in list)
            {
                if (mgg.Code==upload.Code)
                {
                    product.GiaBan = product.GiaBan-( product.GiaBan  * mgg.SoPhanTramGiam / 100);
                }
            }
            var response = new
            {
                Id = product.Id,
                GiaBan =product.GiaBan
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }
    }
}
