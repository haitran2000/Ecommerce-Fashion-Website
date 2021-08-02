using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class UserManagersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DPContext _context;
        public UserManagersController(DPContext context, UserManager<AppUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> Gets()
        {
            return await _userManager.Users.ToListAsync();
        }
    }
}
