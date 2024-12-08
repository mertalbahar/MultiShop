using MultiShop.Catalog.WebApi.Dtos.DiscountOfferDtos;

namespace MultiShop.Catalog.WebApi.Services.DiscountOfferServices
{
    public interface IDiscountOfferService
    {
        Task<List<ResultDiscountOfferDto>> GetAllDiscountOffersAsync();
        Task<GetByIdDiscountOfferDto> GetDiscountOfferByIdAsync(string id);
        Task CreateDiscountOfferAsync(CreateDiscountOfferDto createDiscountOfferDto);
        Task UpdateDiscountOfferAsync(UpdateDiscountOfferDto updateDiscountOfferDto);
        Task DeleteDiscountOfferAsync(string id);
    }
}
