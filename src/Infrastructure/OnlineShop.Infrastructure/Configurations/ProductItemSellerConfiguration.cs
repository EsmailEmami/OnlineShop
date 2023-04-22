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
    public class ProductItemSellerConfiguration : IEntityTypeConfiguration<ProductItemSeller>
    {
        public void Configure(EntityTypeBuilder<ProductItemSeller> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ProductItem).WithMany(x => x.Sellers).HasForeignKey(x => x.ProductItemId).IsRequired();
            builder.HasOne(x => x.Seller).WithMany(x => x.Products).HasForeignKey(x => x.SellerId).IsRequired();
            builder.HasQueryFilter(x => x.IsActive);
        }
    }
}
