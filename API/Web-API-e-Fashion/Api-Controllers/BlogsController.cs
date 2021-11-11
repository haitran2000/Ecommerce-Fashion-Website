﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.ClientToServerModels;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Models;
using Web_API_e_Fashion.SignalRModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : Controller
    {
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly DPContext _context;
        public BlogsController(DPContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            this._context = context;
            this._hubContext = hubContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogAndImage>>> GetllBlogs()
        {
            try
            {
                var blogs = _context.Blogs.Select(b => new BlogAndImage()
                {

                    Id = b.Id,
                    TieuDe = b.TieuDe,
                    NoiDung = b.NoiDung,
                    image = _context.ImageBlogs.Where(s => s.FkBlogId == b.Id).Select(s => s.ImageName).FirstOrDefault(),
                    nameUser = _context.AppUsers.Where(s => s.Id == b.FkAppUser_NguoiThem).Select(s => s.FirstName + " " + s.LastName).FirstOrDefault(),

                });
                return await blogs.ToListAsync();
            }
            catch (Exception ex)
            {
                var a = ex;
                return BadRequest(ex);
            }

        }

        public class BlogAndImage
        {
            public int Id { get; set; }
            public string TieuDe { get; set; }
            public string NoiDung { get; set; }
            public string image { get; set; }
            public string nameUser { get; set; }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(int id, [FromForm] UploadBlog upload)
        {
            var listImage = new List<ImageBlog>();
            Blog blog = new Blog();
            blog = await _context.Blogs.FindAsync(id);
            blog.TieuDe = upload.TieuDe;
            blog.NoiDung = upload.NoiDung;
            blog.FkAppUser_NguoiThem = upload.FkUserId;

            Blog sp;
            sp = _context.Blogs.Find(id);


            Notification notification = new Notification()
            {
                TenSanPham = upload.TieuDe,
                TranType = "Edit"
            };
            _context.Notifications.Add(notification);
            ImageBlog[] images = _context.ImageBlogs.Where(s => s.FkBlogId == id).ToArray();
            _context.ImageBlogs.RemoveRange(images);
            ImageBlog image = new ImageBlog();
            var file = upload.files.ToArray();
            var imageBlogs = _context.ImageBlogs.ToArray().Where(s => s.FkBlogId == id);
            foreach (var i in imageBlogs)
            {
                try
                {
                    System.IO.File.Delete(Path.Combine("wwwroot/Images/list-image-blog", i.ImageName));
                }
                catch (Exception)
                {

                }

            }
            if (upload.files != null)
            {
                for (int i = 0; i < file.Length; i++)
                {

                    if (file[i].Length > 0)
                    {
                        var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/Images/list-image-blog",
                       upload.TieuDe + i + "." + file[i].FileName.Split(".")[file[i].FileName.Split(".").Length - 1]);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file[i].CopyToAsync(stream);
                        }

                        listImage.Add(new ImageBlog()
                        {
                            ImageName = upload.TieuDe + i + "." + file[i].FileName.Split(".")
                            [file[i].FileName.Split(".").Length - 1],
                            FkBlogId = blog.Id,
                        });
                    }
                }


            }
            else // xu li khi khong cap nhat hinh
            {
                List<ImageBlog> List;
                List = _context.ImageBlogs.Where(s => s.FkBlogId == id).ToList();
                foreach (ImageBlog img in List)
                    listImage.Add(new ImageBlog()
                    {
                        ImageName = img.ImageName,
                        FkBlogId = blog.Id,
                    }); ;
            };
            blog.ImageBlogs = listImage;
            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }
        [HttpPost("getBlog")]
        public async Task<ActionResult> GetBlog()
        {
            var resuft = _context.Blogs.Select(d=>
            new { 
                id=d.Id,
                tieude=d.TieuDe,
                noidung =d.NoiDung,
                image = _context.ImageBlogs.Where(s=>s.FkBlogId==d.Id).Select(d=>d.ImageName).SingleOrDefault(),
            }).ToList();
            return Json(resuft);
        }

        // POST: api/Blogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog([FromForm] UploadBlog upload)
        {
      
            Blog blog = new Blog();
            blog.TieuDe = upload.TieuDe;
            blog.NoiDung = upload.NoiDung;
            blog.FkAppUser_NguoiThem = upload.FkUserId;
            Notification notification = new Notification()
            {
                TenSanPham = upload.TieuDe,
                TranType = "Add"
            };
            _context.Notifications.Add(notification);
            var file = upload.files.ToArray();

            _context.Blogs.Add(blog);


            await _context.SaveChangesAsync();
            Blog Test;
            Test = await _context.Blogs.FindAsync(blog.Id);
            if (upload.files != null)
            {
                for (int i = 0; i < file.Length; i++)
                {

                    if (file[i].Length > 0)
                    {

                        ImageBlog imageBlog1 = new ImageBlog();
                        _context.ImageBlogs.Add(imageBlog1);
                        await _context.SaveChangesAsync();
                        var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/Images/list-image-blog",
                       upload.TieuDe + imageBlog1.Id + "." + file[i].FileName.Split(".")[file[i].FileName.Split(".").Length - 1]);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file[i].CopyToAsync(stream);
                        }


                        imageBlog1.ImageName = upload.TieuDe + imageBlog1.Id + "." + file[i].FileName.Split(".")
                            [file[i].FileName.Split(".").Length - 1];
                        imageBlog1.FkBlogId = Test.Id;

                        _context.ImageBlogs.Update(imageBlog1);
                        await _context.SaveChangesAsync();

                    }
                }
            }

            await _hubContext.Clients.All.BroadcastMessage();
            return Ok();
        }
        // DELETE: api/Blogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {

            var imageBlogs = _context.ImageBlogs.ToArray().Where(s => s.FkBlogId == id);
            foreach (var i in imageBlogs)
            {
                try
                {
                    System.IO.File.Delete(Path.Combine("wwwroot/Images/list-image-blog", i.ImageName));
                }
                catch (Exception)
                {

                }

            }
            _context.ImageBlogs.RemoveRange(imageBlogs);
            var blog = await _context.Blogs.FindAsync(id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
