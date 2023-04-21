using OnlineShop.Application.Core.Services.CompanyService;
using OnlineShop.Application.Core.Services.CompanyService.Dtos;
using OnlineShop.Domain.Entities.Product;

namespace OnlineShop.Api.Controllers.Web
{
    public class CompanyController : BaseApiController<int, Company, CompanyInputDto, CompanyUpdateDto, CompanyOutputDto>
    {
        public CompanyController(ICompanyService service) : base(service)
        {
        }
    }
}
