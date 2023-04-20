using OnlineShop.Domain.Core;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineShop.Domain.Entities.User
{
    public class State : Entity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<City> Cities { get; set; } = new List<City>();
    }
}
