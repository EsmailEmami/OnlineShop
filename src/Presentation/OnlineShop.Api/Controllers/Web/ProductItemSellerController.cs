using OnlineShop.Application.Core.Services.ProductItemSellerService.Dtos;
using OnlineShop.Application;
using OnlineShop.Domain.Entities.Product;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Data.Core;
using OnlineShop.Application.Core;
using OnlineShop.Common.Dtos;
using OnlineShop.Application.Core.Services.ProductItemSellerService;

namespace OnlineShop.Api.Controllers.Web
{
    public class ProductItemSellerController : BaseApiController<Guid, ProductItemSeller, ProductItemSellerInputDto, ProductItemSellerUpdateDto, ProductItemSellerOutputDto>
    {
        public ProductItemSellerController(IProductItemSellerService service) : base(service)
        {
        }
    }
}
