using OnlineShop.Application.Core.Services.ProductTypeService.Dtos;

namespace OnlineShop.Application.Core.Services.ProductTypeService
{
    public interface IProductTypeService : IApplicationService<int, Domain.Entities.Product.ProductType, ProductTypeInputDto, ProductTypeUpdateDto, ProductTypeOutputDto>
    {
    }
}
