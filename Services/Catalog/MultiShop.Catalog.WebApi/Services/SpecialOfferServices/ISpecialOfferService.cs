using MultiShop.Catalog.WebApi.Dtos.SpecialOfferDtos;

namespace MultiShop.Catalog.WebApi.Services.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync();
        Task<GetByIdSpecialOfferDto> GetSpecialOfferByIdAsync(string id);
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
        Task DeleteSpecialOfferAsync(string id);
    }
}
