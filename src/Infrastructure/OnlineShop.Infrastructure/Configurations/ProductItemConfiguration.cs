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
    public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.HasOne(x => x.Product).WithMany(x => x.Items).HasForeignKey(x => x.ProductId).IsRequired();
            builder.HasOne(x => x.Color).WithMany(x => x.ProductItemColors).HasForeignKey(x => x.ColorId).IsRequired();
        }
    }
}
