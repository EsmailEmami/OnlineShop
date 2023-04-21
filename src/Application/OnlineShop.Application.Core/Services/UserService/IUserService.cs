﻿using OnlineShop.Application.Core.Services.UserService.Dtos;
using OnlineShop.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Core.Services.UserService
{
    public interface IUserService : IApplicationService<long, User, UserInputDto, UserUpdateDto, UserOutputDto, UserSPFInputDto>
    {
    }
}
