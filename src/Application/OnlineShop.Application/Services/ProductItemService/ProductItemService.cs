using OnlineShop.Application.Core.Services.ProductItemService;
using OnlineShop.Application.Core.Services.ProductItemService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Application.Services.ProductItemService
{
    public class ProductItemService : ApplicationService<Guid, ProductItem, ProductItemInputDto, ProductItemUpdateDto, ProductItemOutputDto>, IProductItemService
    {
        public ProductItemService(IMapping mapping, IRepository<ProductItem, Guid> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }
    }
}
