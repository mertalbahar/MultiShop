using AutoMapper;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Infrastructures.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GetByIdCategoryDto, UpdateCategoryDto>();

            CreateMap<GetByIdProductDto, UpdateProductDto>();
        }
    }
}
