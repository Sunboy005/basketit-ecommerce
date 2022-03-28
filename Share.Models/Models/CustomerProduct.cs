using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Models.Models
{
    public class CustomerProduct
    {
        public string ProductName { get; set; } 
        public string ProductDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Price { get; set; }
    }
}
