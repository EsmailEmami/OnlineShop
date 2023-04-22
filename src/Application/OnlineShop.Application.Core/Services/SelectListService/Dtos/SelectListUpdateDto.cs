using OnlineShop.Domain.Entities.System;

namespace OnlineShop.Application.Core.Services.SelectListService.Dtos
{
    public class SelectListUpdateDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public SelectListType SelectListType { get; set; }
    }
}
