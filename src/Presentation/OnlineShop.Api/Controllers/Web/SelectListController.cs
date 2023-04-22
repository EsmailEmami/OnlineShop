using OnlineShop.Application.Core.Services.SelectListService;
using OnlineShop.Application.Core.Services.SelectListService.Dtos;

namespace OnlineShop.Api.Controllers.Web
{
    public class SelectListController : BaseApiController<int, Domain.Entities.System.SelectList, SelectListInputDto, SelectListUpdateDto, SelectListOutputDto>
    {
        public SelectListController(ISelectListService service) : base(service)
        {
        }
    }
}
