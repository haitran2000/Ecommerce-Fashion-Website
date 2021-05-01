using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Models;
using Web_API_e_Fashion.UploadFileModels;

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DPContext _context;

        public UsersController(DPContext context)
        {
            _context = context;
        }
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UploadUser upload)
        {
            User user = new User();
            user = await _context.Users.FirstOrDefaultAsync(s => s.Id == id);
            user.Ten = upload.Ten;
            user.TenDayDu = user.Ho + ' ' + user.Ten;
            user.Ho = upload.Ho;
            user.Nuoc = upload.Nuoc;
            user.GhiChu = upload.GhiChu;
            user.Quan = upload.Quan;
            user.token_reset_pass = null;
            user.email = upload.email;
            user.DiaChiChiTiet = upload.DiaChiChiTiet;
            user.Tinh = upload.Tinh;
            user.Update_By = upload.Update_By;
            user.Update_Date = DateTime.Now;
            user.Create_Date = null;
            user.TrangThai = upload.TrangThai;
            var folderName = Path.Combine("Resources", "Images", "user");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fileName = ContentDispositionHeaderValue.Parse(upload.TileImage.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await upload.TileImage.CopyToAsync(stream);
            }
            user.ImagePath = upload.TileImage.FileName;
            user.TenDayDu = user.Ho + ' ' + user.Ten;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromForm] UploadUser upload)
        {
            User user = new User();
            user.Ten = upload.Ten;
            user.TenDayDu = user.Ho + ' ' + user.Ten;
            user.Ho = upload.Ho;
            user.Nuoc = upload.Nuoc;
            user.GhiChu = upload.GhiChu;
            user.Quan = upload.Quan;
            user.token_reset_pass = null;
            user.email = upload.email;
            user.DiaChiChiTiet = upload.DiaChiChiTiet;
            user.Tinh = upload.Tinh;
            user.Update_By = upload.Update_By;
            user.Update_Date = null;
            user.Create_Date = DateTime.Now;
            user.TrangThai = upload.TrangThai;
            var folderName = Path.Combine("Resources", "Images", "user");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fileName = ContentDispositionHeaderValue.Parse(upload.TileImage.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await upload.TileImage.CopyToAsync(stream);
            }
            user.ImagePath = upload.TileImage.FileName;
            user.TenDayDu = user.Ho + ' ' + user.Ten;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
