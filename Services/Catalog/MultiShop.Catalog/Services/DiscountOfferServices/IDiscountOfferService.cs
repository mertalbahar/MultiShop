using MultiShop.Catalog.Dtos.DiscountOfferDtos;

namespace MultiShop.Catalog.Services.DiscountOfferServices
{
    public interface IDiscountOfferService
    {
        Task<List<ResultDiscountOfferDto>> GetAllDiscountOfferAsync();
        Task<GetByIdDiscountOfferDto> GetByIdDiscountOfferAsync(string id);
        Task CreateDiscountOfferAsync(CreateDiscountOfferDto createDiscountOfferDto);
        Task UpdateDiscountOfferAsync(UpdateDiscountOfferDto updateDiscountOfferDto);
        Task DeleteDiscountOfferAsync(string id);
    }
}
