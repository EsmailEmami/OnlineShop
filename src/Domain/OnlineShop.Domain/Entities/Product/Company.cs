using OnlineShop.Domain.Core;

namespace OnlineShop.Domain.Entities.Product
{
    public class Company : Entity<int>
    {
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
