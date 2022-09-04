using Core;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductWithCategory()
        {
            //eager loaing ilk olarak data çekilmesi
           return await _context.Products.Include(x=>x.Category).ToListAsync();
            //lazy loading ihtiyaç olması durumunda data çekilmesi
            
        }
    }
}
