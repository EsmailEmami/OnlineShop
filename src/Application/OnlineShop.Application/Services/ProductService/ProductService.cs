using OnlineShop.Application.Core.Services.ProductService;
using OnlineShop.Application.Core.Services.ProductService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Application.Services.ProductService
{
    public class ProductService : ApplicationService<Guid, Product, ProductInputDto, ProductUpdateDto, ProductOutputDto>, IProductService
    {
        public ProductService(IMapping mapping, IRepository<Product, Guid> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }
    }
}
