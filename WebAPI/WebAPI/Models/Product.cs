using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public float Prix { get; set; }

        public string Description { get; set; }
    }
}
