using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class DuyetCommentController : ControllerBase
    {
        private readonly DPContext _context;
        public DuyetCommentController(DPContext context)
        {
            this._context = context;
        }
        [HttpPost]
        public async Task<ActionResult> PostComment(UserComment comment)
        {
            UserComment cmt = new UserComment();
            cmt.Content = comment.Content;
            cmt.IdSanPham = comment.IdSanPham;
            cmt.IdAppUser = comment.IdAppUser;
            cmt.TrangThaiHienThi = comment.TrangThaiHienThi;
            _context.UserComments.Add(comment);
            await _context.SaveChangesAsync();
            return Ok();
        } 
    }
}
