using OnlineShop.Application.Core.Services.ProductDetailKeyValueService;
using OnlineShop.Application.Core.Services.ProductDetailKeyValueService.Dtos;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Api.Controllers.Web
{
    public class ProductDetailKeyValueController : BaseApiController<Guid, ProductDetailKeyValue, ProductDetailKeyValueInputDto, ProductDetailKeyValueUpdateDto, ProductDetailKeyValueOutputDto>
    {
        public ProductDetailKeyValueController(IProductDetailKeyValueService service) : base(service)
        {
        }
    }
}
