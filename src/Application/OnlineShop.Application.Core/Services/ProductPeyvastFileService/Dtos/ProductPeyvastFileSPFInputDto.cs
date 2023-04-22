using OnlineShop.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Core.Services.ProductPeyvastFileService.Dtos
{
    public class ProductPeyvastFileSPFInputDto : SPFInputDto
    {
        public Guid ProductId { get; set; } 
    }
}
