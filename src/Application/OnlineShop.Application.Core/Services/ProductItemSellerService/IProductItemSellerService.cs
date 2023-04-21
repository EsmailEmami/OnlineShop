using OnlineShop.Application.Core.Services.ProductItemSellerService.Dtos;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Application.Core.Services.ProductItemSellerService
{
    public interface IProductItemSellerService : IApplicationService<Guid, ProductItemSeller, ProductItemSellerInputDto, ProductItemSellerUpdateDto, ProductItemSellerOutputDto>
    {
    }
}
