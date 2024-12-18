﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.WebApi.Dtos;
using MultiShop.Discount.WebApi.Services;

namespace MultiShop.Discount.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscountsController : ControllerBase
{
    private readonly IDiscountService _discountService;

    public DiscountsController(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    [HttpGet]
    public async Task<IActionResult> DiscountCouponList()
    {
        List<ResultDiscountCouponDto> values = await _discountService.GetAllDiscountCouponAsync();

        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDiscountCouponById(int id)
    {
        GetByIdDiscountCouponDto value = await _discountService.GetByIdDiscountCouponAsync(id);

        return Ok(value);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createDiscountCouponDto)
    {
        await _discountService.CreateDiscountCouponAsync(createDiscountCouponDto);

        return Ok("İndirim kuponu başarıyla oluşturuldu.");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteDiscountCoupon(int id)
    {
        await _discountService.DeleteDiscountCouponAsync(id);

        return Ok("İndirim kuponu başarıyla silindi.");
    }
    [HttpPut("update")]
    public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateDiscountCouponDto)
    {
        await _discountService.UpdateDiscountCouponAsync(updateDiscountCouponDto);

        return Ok("İndirim kuponu başarıyla güncellendi.");
    }

    [HttpGet("discountCode/{code}")]
    public async Task<IActionResult> GetDiscountCouponByCode(string code)
    {
        ResultDiscountCouponDto value = await _discountService.GetByCodeDiscountCouponAsync(code);

        return Ok(value);
    }
}
