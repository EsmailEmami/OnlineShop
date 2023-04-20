using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Configurations
{
    public class ProductPeyvastFileConfiguration : IEntityTypeConfiguration<ProductPeyvastFile>
    {
        public void Configure(EntityTypeBuilder<ProductPeyvastFile> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(c=> c.Product).WithMany(x=> x.Pics).HasForeignKey(x=>x.ProductId).IsRequired();
            builder.HasOne(c=> c.PeyvastFile).WithMany(x=> x.ProductPeyvastFiles).HasForeignKey(x=>x.PeyvastFileId).IsRequired();
        }
    }
}
