using OnlineShop.Application.Core.Services.ProductDetailKeyService;
using OnlineShop.Application.Core.Services.ProductDetailKeyService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Application.Services.ProductDetailKeyService
{
    public class ProductDetailKeyService : ApplicationService<int, ProductDetailKey, ProductDetailKeyInputDto, ProductDetailKeyUpdateDto, ProductDetailKeyOutputDto>, IProductDetailKeyService
    {
        public ProductDetailKeyService(IMapping mapping, IRepository<ProductDetailKey, int> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }
    }
}
