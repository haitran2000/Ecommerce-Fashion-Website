
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Web_API_e_Fashion.Data;
using Web_API_e_Fashion.Helpers;
using Web_API_e_Fashion.Models;
using Web_API_e_Fashion.ViewModels;

namespace Web_API_e_Fashion.Api_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly DPContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountsController(UserManager<AppUser> userManager, IMapper mapper, DPContext context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
        }
        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<AppUser>(model);

          
                var folderName = Path.Combine("Resources", "Images", "user");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fileName = ContentDispositionHeaderValue.Parse(model.file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await model.file.CopyToAsync(stream);
                }

            

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            AppUser user = new AppUser();
            user = await _context.AppUsers.FirstOrDefaultAsync(s => s.Id == userIdentity.Id);
            user.ImagePath = fileName;

            _context.AppUsers.Update(user);
            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            await _context.JobSeekers.AddAsync(new JobSeeker { IdentityId = userIdentity.Id, Location = model.Location });
            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}