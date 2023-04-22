using OnlineShop.Application.Core.Services.ProductPeyvastFileService;
using OnlineShop.Application.Core.Services.ProductPeyvastFileService.Dtos;
using OnlineShop.Application.Mapping;
using OnlineShop.Data.Core;
using OnlineShop.Data.Core.Repositories;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Application.Services.ProductPeyvastFileService
{
    public class ProductPeyvastFileService : ApplicationService<Guid, ProductPeyvastFile, ProductPeyvastFileInputDto, ProductPeyvastFileUpdateDto, ProductPeyvastFileOutputDto, ProductPeyvastFileSPFInputDto>, IProductPeyvastFileService
    {
        public ProductPeyvastFileService(IMapping mapping, IRepository<ProductPeyvastFile, Guid> repository, IUnitOfWork unitOfWork) : base(mapping, repository, unitOfWork)
        {
        }

        public override void RunSPFFilter(ref IQueryable<ProductPeyvastFile> qry, ProductPeyvastFileSPFInputDto model)
        {
            qry = qry.Where(x=> x.ProductId == model.ProductId);

            base.RunSPFFilter(ref qry, model);
        }
    }
}
