using OnlineShop.Application.Core.Services.ProductType.Dtos;

namespace OnlineShop.Application.Core.Services.ProductType
{
    public interface IProductTypeService : IApplicationService<int, Domain.Entities.Product.ProductType, ProductTypeInputDto, ProductTypeUpdateDto, ProductTypeOutputDto>
    {
    }
}
