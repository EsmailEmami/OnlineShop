using OnlineShop.Application.Core.Services.SellerService.Dtos;
using OnlineShop.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Core.Services.SellerService
{
    public interface ISellerService : IApplicationService<long, Seller, SellerInputDto, SellerUpdateDto, SellerOutputDto>
    {
    }
}
