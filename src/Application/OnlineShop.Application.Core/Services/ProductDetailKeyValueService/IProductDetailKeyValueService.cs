using OnlineShop.Application.Core.Services.ProductDetailKeyValueService.Dtos;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Application.Core.Services.ProductDetailKeyValueService
{
    public interface IProductDetailKeyValueService : IApplicationService<Guid, ProductDetailKeyValue, ProductDetailKeyValueInputDto, ProductDetailKeyValueUpdateDto, ProductDetailKeyValueOutputDto>
    {
    }
}
