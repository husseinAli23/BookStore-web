using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Model
{
    public class Book
    {
        public int ID { get; set; }
        public string Title{ get; set; }
        public string description { get; set; }
        public string ImageURL { get; set; }
        public Auther Auther{ get; set; }
       
    }
}
