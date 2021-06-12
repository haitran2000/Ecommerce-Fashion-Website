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
using Web_API_e_Fashion.SignalRModels;
using Web_API_e_Fashion.UploadDataFormClientModels;

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly DPContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        public ItemsController(DPContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }


        // GET: api/Items
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, [FromForm] UploadItem upload)
        {
            Notification notification = new Notification()
            {
                TenSanPham = upload.TileImage.FileName,
                TranType = "Edit"
            };
            _context.Notifications.Add(notification);

            Item item = new Item();
            item = await _context.Items.FirstOrDefaultAsync(c => c.Id == id);
            item.TrangThai = upload.TrangThai;
            if (upload.TileImage != null)
            {
                var folderName = Path.Combine("Resources", "Images", "item");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fileName = ContentDispositionHeaderValue.Parse(upload.TileImage.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await upload.TileImage.CopyToAsync(stream);
                }
                item.HinhAnh = upload.TileImage.FileName;
            }
            else
            {
                item.HinhAnh = "noimage.jpg";
            }
            _context.Items.Update(item);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem([FromForm] UploadItem upload)
        {
            byte[] a;
            Notification notification = new Notification()
            {
                TenSanPham = upload.TileImage.FileName,
                TranType = "Add"
            };
       
            _context.Notifications.Add(notification);
            Item item = new Item();
            using (var stream = new MemoryStream())
            {
                await upload.TileImage.CopyToAsync(stream);
                a = stream.ToArray();
                var base64 = Convert.ToBase64String(a);
                item.DataHinhAnh = string.Format("data:image/png;base64,{0}", base64);

            }
            item.TrangThai = upload.TrangThai;
            if (upload.TileImage != null)
            {
                var folderName = Path.Combine("Resources", "Images", "item");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fileName = ContentDispositionHeaderValue.Parse(upload.TileImage.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await upload.TileImage.CopyToAsync(stream);
                }
                item.HinhAnh = upload.TileImage.FileName;
            }
            else
            {
                item.HinhAnh = "noimage.jpg";
            }
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            Notification notification = new Notification()
            {
                TenSanPham = item.HinhAnh,
                TranType = "Delete"
            };
            _context.Notifications.Add(notification);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();
            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
