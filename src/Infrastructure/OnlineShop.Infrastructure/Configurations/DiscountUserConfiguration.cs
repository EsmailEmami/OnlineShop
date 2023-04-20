using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Configurations
{
    public class DiscountUserConfiguration : IEntityTypeConfiguration<DiscountUser>
    {
        public void Configure(EntityTypeBuilder<DiscountUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(c => c.User).WithMany(x => x.DiscountUsers).HasForeignKey(x => x.UserId).IsRequired();
            builder.HasOne(c => c.Discount).WithMany(x => x.DiscountUsers).HasForeignKey(x => x.DiscountId).IsRequired();
        }
    }
}
