using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class JobSeeker
    {
        [Key]
        public int Id { get; set; }
        public string IdentityId { get; set; }
        [ForeignKey("IdentityId")]
        public virtual AppUser Identity { get; set; }  // navigation property
        public string Location { get; set; }
    }
}
