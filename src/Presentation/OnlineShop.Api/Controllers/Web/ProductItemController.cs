using OnlineShop.Application.Core.Services.ProductItemService;
using OnlineShop.Application.Core.Services.ProductItemService.Dtos;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Api.Controllers.Web
{
    public class ProductItemController : BaseApiController<Guid, ProductItem, ProductItemInputDto, ProductItemUpdateDto, ProductItemOutputDto>
    {
        public ProductItemController(IProductItemService service) : base(service)
        {
        }
    }
}
