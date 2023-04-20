using OnlineShop.Domain.Core;

namespace OnlineShop.Domain.Entities.Discount
{
    public class DiscountUser : Entity<long>
    {
        public long UserId { get; set; }
        public virtual User.User User { get; set; }

        public long DiscountId { get; set; }
        public virtual Discount Discount { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }
    }
}
