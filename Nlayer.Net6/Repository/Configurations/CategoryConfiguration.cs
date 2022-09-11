using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        /// <summary>
        /// bu şeikilde oncreation methodumuz çok daınık olmayacaktır Tablolar için kullanılır.Buradan tablo adını foreign key değerleri ya da atamalarını yapabilirsin
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            ////builder.HasKey(x => x.Id).HasName("ProuductName"); 
            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).UseIdentityColumn();
            //builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            //throw new NotImplementedException();
        }
    }
}
