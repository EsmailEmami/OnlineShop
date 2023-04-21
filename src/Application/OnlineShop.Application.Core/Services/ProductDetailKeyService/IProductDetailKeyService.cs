using OnlineShop.Application.Core.Services.ProductDetailKeyService.Dtos;
using OnlineShop.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Core.Services.ProductDetailKeyService
{
    public interface IProductDetailKeyService : IApplicationService<int, ProductDetailKey, ProductDetailKeyInputDto, ProductDetailKeyUpdateDto, ProductDetailKeyOutputDto>
    {
    }
}
