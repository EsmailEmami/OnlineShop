using OnlineShop.Application.Core.Services.ProductItemSellerService;
using OnlineShop.Application.Core.Services.ProductItemSellerService.Dtos;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Api.Controllers.Web
{
    public class ProductItemSellerController : BaseApiController<Guid, ProductItemSeller, ProductItemSellerInputDto, ProductItemSellerUpdateDto, ProductItemSellerOutputDto>
    {
        public ProductItemSellerController(IProductItemSellerService service) : base(service)
        {
        }
    }
}
