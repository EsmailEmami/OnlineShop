using OnlineShop.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities.User
{
    public class City : Entity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public int StateId { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
