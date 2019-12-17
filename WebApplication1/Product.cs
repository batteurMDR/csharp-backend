using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Product
    {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string CodeBarre { get; set; }
        public string Description { get; set; }
        public float Prix { get; set; }
        public int Stock { get; set; }
    }
}
