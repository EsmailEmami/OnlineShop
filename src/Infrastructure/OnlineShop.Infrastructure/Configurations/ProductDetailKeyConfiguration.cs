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
    public class ProductDetailKeyConfiguration : IEntityTypeConfiguration<ProductDetailKey>
    {
        public void Configure(EntityTypeBuilder<ProductDetailKey> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=> x.ProductType).WithMany(x=> x.ProductDetailKeys).HasForeignKey(x=>x.ProductTypeId).IsRequired();
        }
    }
}
