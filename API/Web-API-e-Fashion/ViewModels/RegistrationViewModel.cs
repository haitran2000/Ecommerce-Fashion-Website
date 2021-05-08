using FluentValidation.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_e_Fashion.ViewModels.Validations;

namespace Web_API_e_Fashion.ViewModels
{
   
        [Validator(typeof(RegistrationViewModelValidator))]
        public class RegistrationViewModel
        {
            public IFormFile file { get; set; }  
            public string Email { get; set; }
            public string Password { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Location { get; set; }
        }
}
