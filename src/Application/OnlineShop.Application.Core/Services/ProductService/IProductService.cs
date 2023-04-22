using OnlineShop.Application.Core.Services.ProductService.Dtos;
using OnlineShop.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Core.Services.ProductService
{
    public interface IProductService : IApplicationService<Guid, Product, ProductInputDto, ProductUpdateDto, ProductOutputDto, ProductSPFInputDto>
    {
        ProductDetailOutputDto GetProductDetail(Guid productId);
    }
}
