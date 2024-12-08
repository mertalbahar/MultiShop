﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.WebApi.Dtos;
using MultiShop.Basket.WebApi.LoginServices;
using MultiShop.Basket.WebApi.Services;

namespace MultiShop.Basket.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketsController : ControllerBase
{
    private readonly IBasketService _basketService;
    private readonly ILoginService _loginService;

    public BasketsController(IBasketService basketService, ILoginService loginService)
    {
        _basketService = basketService;
        _loginService = loginService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMyBasket()
    {
        var user = User.Claims;
        BasketTotalDto values = await _basketService.GetBasket(_loginService.GetUserId);

        return Ok(values);
    }


    [HttpPost]
    public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
    {
        basketTotalDto.UserId = _loginService.GetUserId;
        await _basketService.SaveBasket(basketTotalDto);

        return Ok("Sepetteki değişiklikler kaydedildi.");
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteMyBasket()
    {
        await _basketService.DeleteBasket(_loginService.GetUserId);

        return Ok("Sepet başarıyla silindi.");
    }
}
