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
    public class ProductDetailKeyValueConfiguration : IEntityTypeConfiguration<ProductDetailKeyValue>
    {
        public void Configure(EntityTypeBuilder<ProductDetailKeyValue> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ProductDetailKey).WithMany(x => x.ProductDetailKeyValues).HasForeignKey(x => x.ProductDetailKeyId)
                .IsRequired();

            builder.HasOne(x => x.Product).WithMany(x => x.ProductDetailKeyValues).HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
