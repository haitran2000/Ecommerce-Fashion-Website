using System;
using System.Collections.Generic;
using System.Linq;
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
    public class SizesController : ControllerBase
    {
        private readonly DPContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        public SizesController(DPContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        // GET: api/Sizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SizeLoai>>> GetSizes()
        {
            var kb = from l in _context.Loais
                     join s in _context.Sizes
                     on l.Id equals s.Id_Loai
                     select new SizeLoai()
                     {
                         Id = s.Id,
                         TenLoai = l.Ten,
                         TenSize = s.TenSize
                     };
            return await kb.ToListAsync();
        }
        [HttpGet("tensizeloai")]
        public async Task<ActionResult<IEnumerable<TenSizeLoai>>> GetTenSizeLoais()
        {
            var kb = from m in _context.Sizes
                     join l in _context.Loais
                     on m.Id_Loai equals l.Id
                     select new TenSizeLoai()
                     {
                         Id = m.Id,
                         SizeLoaiTen = m.TenSize+" "+l.Ten
                     };
            var kbs = kb.ToListAsync();
            return await kbs;
        }
        // GET: api/Sizes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Size>> GetSize(int id)
        {
            var size = await _context.Sizes.FindAsync(id);

            if (size == null)
            {
                return NotFound();
            }

            return size;
        }

        // PUT: api/Sizes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSize(int id, [FromForm] UploadSize upload)
        {

            Size size;
            size = await _context.Sizes.FindAsync(id);
            size.TenSize = upload.TenSize;
            size.Id_Loai = upload.Id_Loai;
            _context.Sizes.Update(size);

          
            Notification notification = new Notification()
            {
                TenSanPham = upload.TenSize,
                TranType = "Edit"
            };
            _context.Notifications.Add(notification);
            await _hubContext.Clients.All.BroadcastMessage();
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Sizes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Size>> PostSize([FromForm]UploadSize upload)
        {
            Size size = new Size()
            {
                TenSize = upload.TenSize,
                Id_Loai = upload.Id_Loai,
            };

            _context.Sizes.Add(size);
            Notification notification = new Notification()
            {
                TenSanPham = upload.TenSize,
                TranType = "Add"
            };
            _context.Notifications.Add(notification);
            await _hubContext.Clients.All.BroadcastMessage();
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSize", new { id = size.Id }, size);
        }

        // DELETE: api/Sizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSize(int id)
        {
            var size = await _context.Sizes.FindAsync(id);
            if (size == null)
            {
                return NotFound();
            }

            _context.Sizes.Remove(size);
            Notification notification = new Notification()
            {
                TenSanPham = size.TenSize,
                TranType = "Delete"
            };
            _context.Notifications.Add(notification);
            await _hubContext.Clients.All.BroadcastMessage();
            await _context.SaveChangesAsync();
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SizeExists(int id)
        {
            return _context.Sizes.Any(e => e.Id == id);
        }
    }
}
