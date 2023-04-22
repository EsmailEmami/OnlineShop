using OnlineShop.Domain.Entities.System;

namespace OnlineShop.Application.Core.Services.SelectListService.Dtos
{
    public class SelectListOutputDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public SelectListType SelectListType { get; set; }
        public string SelectListTypeName { get; set; }
    }
}
