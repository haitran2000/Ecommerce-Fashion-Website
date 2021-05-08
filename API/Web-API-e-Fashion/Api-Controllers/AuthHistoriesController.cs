using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.Data;

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthHistoriesController : ControllerBase
    {
        private readonly DPContext _context;
        public AuthHistoriesController(DPContext context)
        {
            _context = context;
        }

    }
}
