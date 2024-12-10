namespace MultiShop.Discount.WebApi.Services
{
    public interface IStatisticService
    {
        Task<int> GetDiscountCouponCount();
    }
}
