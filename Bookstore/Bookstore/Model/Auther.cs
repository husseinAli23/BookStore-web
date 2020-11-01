using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Model
{
    public class Auther
    {
        public int id{ get; set; }
        [Required]
        [StringLength(20,MinimumLength =5)]
        public string Fullname { get; set; }
    }
}
