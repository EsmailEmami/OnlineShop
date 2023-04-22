using OnlineShop.Application.Core.Services.ProductPeyvastFileService.Dtos;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Application.Core.Services.ProductPeyvastFileService
{
    public interface IProductPeyvastFileService : IApplicationService<Guid, ProductPeyvastFile, ProductPeyvastFileInputDto, ProductPeyvastFileUpdateDto, ProductPeyvastFileOutputDto, ProductPeyvastFileSPFInputDto>
    {
    }
}
