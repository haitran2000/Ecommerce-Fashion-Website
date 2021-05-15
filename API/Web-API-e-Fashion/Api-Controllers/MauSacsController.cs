﻿using System;
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
using Web_API_e_Fashion.SignalRModels;
using Web_API_e_Fashion.UploadDataFormClientModels;

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MauSacsController : ControllerBase
    {
        private readonly DPContext _context;
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        public MauSacsController(DPContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        // GET: api/MauSacs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MauSacLoai>>> GetMauSacs()
        {
            var kb = from l in _context.Loais
                     join s in _context.MauSacs
                     on l.Id equals s.Id_Loai
                     select new MauSacLoai()
                     {
                         Id = s.Id,
                         TenLoai = l.Ten,
                        MaMau = s.MaMau
                     };
            return await kb.ToListAsync();
        }

        // GET: api/MauSacs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MauSac>> GetMauSac(int id)
        {
            var mauSac = await _context.MauSacs.FindAsync(id);

            if (mauSac == null)
            {
                return NotFound();
            }

            return mauSac;
        }

        // PUT: api/MauSacs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMauSac(int id, [FromForm]UploadMauSac upload)
        {
            MauSac mausac;
            mausac = await _context.MauSacs.FindAsync(id);
            mausac.MaMau = upload.MaMau;
           mausac.Id_Loai = upload.Id_Loai;
            _context.MauSacs.Update(mausac);
            Notification notification = new Notification()
            {
                TenSanPham = upload.MaMau,
                TranType = "Edit"
            };
            _context.Notifications.Add(notification);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MauSacExists(id))
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

        // POST: api/MauSacs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MauSac>> PostMauSac([FromForm] UploadMauSac upload)
        { 
            Notification notification = new Notification()
            {
                TenSanPham = upload.MaMau,
                TranType = "Add"
            };
            _context.Notifications.Add(notification);
            MauSac mausac = new MauSac()
            {
                MaMau = upload.MaMau,
                Id_Loai = upload.Id_Loai,
            };
            _context.MauSacs.Add(mausac);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }

        // DELETE: api/MauSacs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMauSac(int id)
        {
          
            var mauSac = await _context.MauSacs.FindAsync(id);
            Notification notification = new Notification()
            {
                TenSanPham = mauSac.MaMau,
                TranType = "Delete"
            };
            _context.Notifications.Add(notification);
            if (mauSac == null)
            {
                return NotFound();
            }

            _context.MauSacs.Remove(mauSac);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }

        private bool MauSacExists(int id)
        {
            return _context.MauSacs.Any(e => e.Id == id);
        }
    }
}
