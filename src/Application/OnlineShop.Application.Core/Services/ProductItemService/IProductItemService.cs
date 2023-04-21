using OnlineShop.Application.Core.Services.ProductItemService.Dtos;
using OnlineShop.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Core.Services.ProductItemService
{
    public interface IProductItemService : IApplicationService<Guid, ProductItem, ProductItemInputDto, ProductItemUpdateDto, ProductItemOutputDto>
    {
    }
}
