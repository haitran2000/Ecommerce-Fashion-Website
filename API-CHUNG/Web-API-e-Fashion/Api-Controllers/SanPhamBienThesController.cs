using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Models;
using Web_API_e_Fashion.ResModels;
using Web_API_e_Fashion.ServerToClientModels;
using Web_API_e_Fashion.SignalRModels;
using Web_API_e_Fashion.UploadDataFormClientModels;

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamBienThesController : ControllerBase
    {
        private readonly DPContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        public SanPhamBienThesController(DPContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }


        [HttpGet("sanphambienthe")]
        public async Task<ActionResult<IEnumerable<SanPhamBienTheMauSizeLoai>>> GetAllSPBTSS()
        {
            var kb = from spbt in _context.SanPhamBienThes
                     join sp in _context.SanPhams
                     on spbt.Id_SanPham equals sp.Id
                     join l in _context.Loais
                     on sp.Id_Loai equals l.Id
                     join m in _context.MauSacs
                     on spbt.Id_Mau equals m.Id
                     join s in _context.Sizes
                     on spbt.SizeId equals s.Id

                     select new SanPhamBienTheMauSizeLoai()
                     {
                         Id = spbt.Id,
                         MauLoai = m.MaMau + " " + l.Ten,
                         SizeLoai = s.TenSize + " " + l.Ten,
                         SanPham = sp.Ten,

                     };
            return await kb.ToListAsync();
        }
        // GET: api/SanPhamBienThes
        [HttpGet("spbt/{id}")]
        public async Task<ActionResult<IEnumerable<SanPhamBienThe>>> GetSPBTAll(int id)
        {
            return await _context.SanPhamBienThes.Where(s=>s.Id_SanPham==id).ToListAsync();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiaSanPham_MauSac_SanPham_Size>>> GetSanPhamBienThes()
        {
            var kb = from g in _context.SanPhamBienThes
                     join m in _context.MauSacs
                     on g.Id_Mau equals m.Id
                     join sp in _context.SanPhams
                     on g.Id_SanPham equals sp.Id
                     join s in _context.Sizes
                     on g.SizeId equals s.Id
                     select new GiaSanPham_MauSac_SanPham_Size()
                     {
                         //DataHinhAnh = g.DataHinhAnh,
                         //ImagePath = g.ImagePath,
                         Id = g.Id,
                         MaMau = m.MaMau,
                         TenSanPham = sp.Ten,
                        TenSize = s.TenSize,
                     };
            return await kb.ToListAsync();
        }

        // GET: api/SanPhamBienThes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPhamBienThe>> Get(int id)
        {
            var giaSanPham = await _context.SanPhamBienThes.FindAsync(id);

            if (giaSanPham == null)
            {
                return NotFound();
            }

            return giaSanPham;
        }

        // PUT: api/SanPhamBienThes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanPhamBienTh(int id, [FromForm] UploadSanPhamBienThe upload)
        {

            SanPhamBienThe spbt;
            spbt = await _context.SanPhamBienThes.FindAsync(id);
            spbt.Id_Mau = upload.MauId;
            spbt.Id_SanPham = upload.SanPhamId;
          
            try
            {
                _context.SanPhamBienThes.Update(spbt);
             
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiaSanPhamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            Notification notification = new Notification()
            {
              
                TranType = "Edit"
            };
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();
            return NoContent();
        
        }

        // POST: api/SanPhamBienThes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SanPhamBienThe>> PostSanPhamBienThe([FromForm] UploadSanPhamBienThe upload)
        {
            byte[] a;

            Notification notification = new Notification()
            {           
                TranType = "Add"
            };

            _context.Notifications.Add(notification);
            SanPhamBienThe spbt = new SanPhamBienThe()
            {
                Id_SanPham = upload.SanPhamId,
                SizeId = upload.SizeId,
                Id_Mau = upload.MauId,
                
            };
           
           
            _context.SanPhamBienThes.Add(spbt);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }

        // DELETE: api/SanPhamBienThes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanPhamBienTh(int id)
        {
            SanPhamBienThe spbt;
            spbt = await _context.SanPhamBienThes.FindAsync(id);
          

            _context.SanPhamBienThes.Remove(spbt);
            Notification notification = new Notification()
            {
                //TenSanPham = spbt.ImagePath,
                TranType = "Delete",
            };
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }

        private bool GiaSanPhamExists(int id)
        {
            return _context.SanPhamBienThes.Any(e => e.Id == id);
        }
    }
}
