using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Properties { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }


    }
}
