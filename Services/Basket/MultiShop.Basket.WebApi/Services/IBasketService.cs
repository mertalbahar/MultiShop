﻿using MultiShop.Basket.WebApi.Dtos;

namespace MultiShop.Basket.WebApi.Services;

public interface IBasketService
{
    Task<BasketTotalDto> GetBasket(string userId);
    Task SaveBasket(BasketTotalDto basketTotalDto);
    Task DeleteBasket(string userId);
}
