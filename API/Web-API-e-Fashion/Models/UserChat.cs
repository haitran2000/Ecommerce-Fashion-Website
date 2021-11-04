using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.Models
{
    public class UserChat
    { 
        [Key]
        public int Id { get; set; }
        public string ContentChat { get; set; }
        public DateTime TimeChat { get; set; }
        public string? IdUser { get; set; } 
        [ForeignKey("IdUser")]
        public virtual AppUser AppUser { get; set; }
    }
}
