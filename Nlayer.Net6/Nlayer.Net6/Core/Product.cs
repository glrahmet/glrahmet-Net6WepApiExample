using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Product : BaseEntitiy
    {
        //yada editorconfig dosyası ekler ve oradan değişikliği kayıt etmiş olur. 
        //nullable hataları gidermek için bu şekilde de yapabiliriz.
        public Product(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ProductFeature Feature { get; set; }
    }
}
