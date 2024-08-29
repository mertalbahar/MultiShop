﻿using MultiShop.DtoLayer.IdentityDtos;

namespace MultiShop.WebUI.Services.IdentityServices
{
    public interface IUserService
    {
        Task<UserDetailDto> GetUserDetail();
    }
}