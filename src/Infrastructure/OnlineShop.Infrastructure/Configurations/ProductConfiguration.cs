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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ProductType).WithMany(x => x.Products).HasForeignKey(x => x.ProductTypeId).IsRequired();
            builder.HasOne(x => x.Company).WithMany(x => x.Products).HasForeignKey(x => x.CompanyId).IsRequired();
            builder.HasQueryFilter(x => x.IsActive);
        }
    }
}
