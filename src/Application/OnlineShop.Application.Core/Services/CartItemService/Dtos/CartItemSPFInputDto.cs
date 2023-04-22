using OnlineShop.Common.Dtos;

namespace OnlineShop.Application.Core.Services.CartItemService.Dtos
{
    public class CartItemSPFInputDto : SPFInputDto
    {
        public Guid CartId { get; set; }
    }
}
