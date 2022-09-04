using Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        #region onModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //burada isimlendirmelerden dolayı primary key gibi durumlarını değiştirebiliriz.

            //modelBuilder.Entity<Product>().HasKey(x => x.Id).HasName("ProuductName");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        #endregion 
    }
}
