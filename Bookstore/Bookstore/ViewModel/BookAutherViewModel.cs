using Bookstore.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.ViewModel
{
    public class BookAutherViewModel
    {

        public int bookID { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string Title { get; set; }
        [Required]
        [StringLength(120, MinimumLength = 5)]
        public string Description { get; set; }

        public int autherID { get; set; }
        public List<Auther> Authers { get; set; }
        public IFormFile File{ get; set; }

        public string ImageURL { get; set; }
    }
}
