using MultiShop.Catalog.WebApi.Dtos.FeatureSliderDtos;

namespace MultiShop.Catalog.WebApi.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync();
        Task<GetByIdFeatureSliderDto> GetFeatureSliderByIdAsync(string id);
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
    }
}
