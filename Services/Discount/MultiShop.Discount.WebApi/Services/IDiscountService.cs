using MultiShop.Discount.WebApi.Dtos;

namespace MultiShop.Discount.WebApi.Services;

public interface IDiscountService
{
    Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();
    Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id);
    Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto);
    Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto);
    Task DeleteDiscountCouponAsync(int id);
    Task<ResultDiscountCouponDto> GetByCodeDiscountCouponAsync(string code);
}
