using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Models;
using Web_API_e_Fashion.SignalRModels;

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountEntitysController : ControllerBase
    {
        private readonly IHubContext<BroadcastHub, IHubClient> _hubContext;
        private readonly DPContext _context;
        public CountEntitysController(DPContext context, IHubContext<BroadcastHub, IHubClient> hubContext)
        {
            this._context = context;
            this._hubContext = hubContext;
        }

        //Số lượng sản phẩm
        [Route("countproduct")]
        [HttpGet]
        public async Task<ActionResult<int>> GetProductCount()
        {
            int count = await (from not in _context.SanPhams
                         select not).CountAsync();
            return count;
        }


        //Số lượng đơn hàng
        [Route("countorder")]
        [HttpGet]
        public async Task<ActionResult<int>> GetOrderCount()
        {
            int count = await (from not in _context.HoaDons
                               select not).CountAsync();
            return count;
        }


        //Số lượng user
        [Route("countuser")]
        [HttpGet]
        public async Task<ActionResult<int>> GetUserCount()
        {
            int count = await (from not in _context.AppUsers
                               select not).CountAsync();
            return count;
        }


        //Số lượng tiền thu về
        [Route("countmoney")]
        [HttpGet]
        public async Task<ActionResult<decimal>> GetMoneyCount()
        {
            var count = await (from not in _context.HoaDons
                               select not).ToListAsync();
            decimal TongTienTatCa = 0;
            foreach(HoaDon hd in count)
            {
                TongTienTatCa = TongTienTatCa + hd.TongTien;
            }
            return TongTienTatCa;
        }

        //Sản phẩm bán chạy nhất
      
    }

}
