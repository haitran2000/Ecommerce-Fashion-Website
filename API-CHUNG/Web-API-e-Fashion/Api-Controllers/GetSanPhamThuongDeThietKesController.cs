using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Models;
using Web_API_e_Fashion.ResModels;
using Web_API_e_Fashion.UploadDataFormClientModels;

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetSanPhamThuongDeThietKesController : ControllerBase
    {
        private readonly DPContext _context;

        public GetSanPhamThuongDeThietKesController(DPContext context)
        {
            this._context = context;
        }
        //[HttpGet()]
        //public async Task<IEnumerable<SanPhamSanPhamBienThe>> get()
        //{

        //} 
        [HttpGet("getone/{id}")]
        public async Task<SanPhamSanPhamBienThe> getone(int id)
        {
            var kb = from spbt in _context.SanPhamBienThes
                     join sp in _context.SanPhams
                     on spbt.Id_SanPham equals sp.Id
                     select new SanPhamSanPhamBienThe()
                     {
                         IdSP = sp.Id,
                         Hinh = spbt.ImagePath,
                     };
            var kbs = await kb.FirstOrDefaultAsync(s => s.IdSP == id);
            return kbs;

        }
        //[HttpGet("getsptk")]
        //public async Task<IEnumerable<SanPhamThietKe>> get()
        //{
        //    return await _context.SanPhamThietKes.ToListAsync();
           
            //string a = @"/ svg11.dtd";
            //string b = @""">";
            //string c = a + b;
            //List<SanPhamThietKe> listsptk = new List<SanPhamThietKe>();
            //listsptk = _context.SanPhamThietKes.ToList();
            //foreach(SanPhamThietKe item in listsptk)
            //{
                
            //    string[] arrListStr = item.HinhAnh.Split(c);
            //}
            //return  listsptk;
        //}
        [HttpGet]
    
        public async Task<IEnumerable<SanPhamSanPhamBienThe>> Get()
        {
            var kb = from sp in _context.SanPhams
                     join spbt in _context.SanPhamBienThes
                     on sp.Id equals spbt.Id_SanPham
                     select new SanPhamSanPhamBienThe()
                     {
                         IdSP = sp.Id,
                         Hinh = spbt.DataHinhAnh,
                         Name = sp.Ten,
                         Gia = (decimal)sp.Gia,
                         TrangThaiChoPhep = sp.TrangThaiSanPhamThietKe,
                     };
            return await kb.Where(s => s.TrangThaiChoPhep == "co").ToListAsync();
        }
        class SPSPTK
        {
            public int Id;
            public string urlsp;
            public decimal gia;
        }
        public decimal kq;
        int getIdSP(int ss)
        {
            var kb = from sp in _context.SanPhams
                     join spbt in _context.SanPhamBienThes
                     on sp.Id equals spbt.Id_SanPham
                     select new SPSPTK()
                     {
                         Id = sp.Id,
                         urlsp = spbt.ImagePath,
                         gia = (decimal)sp.Gia
                     };
            var q = kb.FirstOrDefault(s => s.Id == ss);

            if (q != null)
            {
                return (int)(kq = q.gia);
            }
            else
            {
                return (int)(kq = -1);
            }

        }
        [HttpPost("json")]
        //public  async Task<IActionResult> Add(JSONcanvas jSONcanvas)
        //{
        //    return Ok();
        //}  
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromForm] UploadSPTK upload, int id)
        {
            //SanPhamThietKe sptk;
            //sptk= await _context.SanPhamThietKes.FindAsync(id);
            //sptk.HinhAnh = upload.file;
            //_context.SanPhamThietKes.Update(sptk);

            //_context.SaveChanges();

            //foreach (string item in upload.urls)
            //{
            //    string[] arrListStr = item.Split('/');
            //    List<SanPham_SanPhamThietKe> sp_sptk;
            //    List<Item_SanPhamThietKe> item_sptk;
            //    SanPhamThietKe[] sp = _context.SanPhamThietKes.Where(s => s.HinhAnh == upload.file).ToArray();
            //    if (arrListStr[5] == "san-pham-bien-the")
            //    {
            //        sp_sptk = (List<SanPham_SanPhamThietKe>)_context.SanPham_SanPhamThietKe.Where(s=>s.SanPhamThietKeId==id);
            //        foreach (SanPham_SanPhamThietKe spt in sp_sptk)
            //        {
            //            spt.SanPhamId = int.Parse(arrListStr[7]);
            //            spt.SanPhamThietKeId = sp[sp.Length - 1].Id;
            //            spt.PublicationDate = DateTime.Now;
            //            _context.SanPham_SanPhamThietKe.Update(spt);
            //        }
                 
            //    }
            //    if (arrListStr[5] == "item")
            //    {
            //        item_sptk = (List<Item_SanPhamThietKe>)_context.Item_SanPhamThietKe.Where(s => s.SanPhamThietKeId == id);
            //        foreach(Item_SanPhamThietKe itema in item_sptk)
            //        {
            //            itema.ItemId = int.Parse(arrListStr[7]);
            //            itema.SanPhamThietKeId = sp[sp.Length - 1].Id;
            //            itema.PublicationDate = DateTime.Now;
            //            _context.Item_SanPhamThietKe.Update(itema);
            //        }
                   
            //    };



            //}
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromForm] UploadSPTK upload)
        {
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(upload.idElement);
            byte[] a;
            List<String> listSrc = new List<string>();
            JObject jobj = JObject.Parse(upload.idElement);
            SanPhamThietKe sptk = new SanPhamThietKe();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var obj = jss.Deserialize<dynamic>(upload.idElement);
             sptk.HinhAnh = upload.file;
            _context.SanPhamThietKes.Add(sptk);
           
            await _context.SaveChangesAsync();
            
            foreach (ResModels.Object item in myDeserializedClass.objects)
            {
                SanPhamThietKe[] sp = _context.SanPhamThietKes.Where(s => s.HinhAnh == upload.file).ToArray();
                string[] arrListStr = item.src.Split('/');
                if (item.src.Contains("data:image/png;base64,") ==true)
                {
                    Item_SanPhamThietKe item_sptk = new Item_SanPhamThietKe();
                    item_sptk.ItemId = GetIdITem(item.src);
                    item_sptk.SanPhamThietKeId = sp[sp.Length - 1].Id;
                    item_sptk.PublicationDate = DateTime.Now;
                    _context.Item_SanPhamThietKe.Add(item_sptk);

                }
                if (item.src.Contains("data:image/jpg;base64,") == true)
                {
                    SanPham_SanPhamThietKe sp_sptk = new SanPham_SanPhamThietKe();
                    sp_sptk.SanPhamId = GetIdSP(item.src);
                    sp_sptk.SanPhamThietKeId = sp[sp.Length - 1].Id;
                    sp_sptk.PublicationDate = DateTime.Now;
                    _context.SanPham_SanPhamThietKe.Add(sp_sptk);
                }
            }
            await _context.SaveChangesAsync();

            return Ok();
        }
        public int GetIdSP(string DataImage)
        {
            var kb = from sp in _context.SanPhams
            join spbt in _context.SanPhamBienThes
            on sp.Id equals spbt.Id_SanPham
            select new SPSPTK()
            { 
                Id = sp.Id,
                urlsp = spbt.DataHinhAnh,
                gia = (decimal)sp.Gia
            };
            SPSPTK q = kb.FirstOrDefault(s => s.urlsp == DataImage);
            return q.Id;
        }
        public int GetIdITem(string DataImage)
        {
            Item q;
             q= _context.Items.FirstOrDefault(s => s.DataHinhAnh == DataImage);
            return q.Id;
        }
        [HttpPost("file")]
        public async Task<IActionResult> Create([FromForm] TestUploadImage test )
        {
            byte[] a;
            TestImage image = new TestImage();
            using (var stream = new MemoryStream())
            {
                await test.file.CopyToAsync(stream);
                a = stream.ToArray();
                var base64 = Convert.ToBase64String(a);
                image.file = string.Format("data:image/gif;base64,{0}", base64);
                image.FileName = test.file.FileName;
            }
            _context.Add(image);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("getdsadsa")]
        public async Task<IEnumerable<TestImage>> getsasa()
        {
            return await _context.TestImages.ToListAsync();
        } 
        private void b64toBlob(string yourBase64String, string FileName)
        {
            var folderName = Path.Combine("Resources", "Images", "sptk");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fileName = FileName;
            var fullPath = Path.Combine(pathToSave, fileName);
            System.IO.File.WriteAllBytes(fullPath, Convert.FromBase64String(yourBase64String));
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        //[HttpPost]
        //public async Task<IActionResult> Add(ListSPTK listSPTK)
        //{
        //    IList<Item> ListItems = new List<Item>();
        //    IList<SanPham> ListSP = new List<SanPham>();
        //    foreach (SanPham sp in listSPTK.ListSP)
        //    {
        //        ListSP.Add(sp);

        //    }
        //    foreach(Item item in listSPTK.ListItem)
        //    {
        //        ListItems.Add(item);
        //    }

        //    SanPhamThietKe sptk = new SanPhamThietKe();
        //    sptk.SanPhams = ListSP;
        //    sptk.Items = ListItems;
        //    _context.SanPhamThietKes.Add(sptk);
        //    await _context.SaveChangesAsync();
        //    return Ok();
        //}
    }
}
