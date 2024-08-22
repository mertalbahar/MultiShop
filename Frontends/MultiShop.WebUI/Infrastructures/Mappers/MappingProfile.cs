using AutoMapper;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.DiscountOfferDtos;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.WebUI.Infrastructures.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GetByIdCategoryDto, UpdateCategoryDto>();

            CreateMap<GetByIdProductDto, UpdateProductDto>();
            CreateMap<GetByIdProductDetailDto, UpdateProductDetailDto>();
            CreateMap<GetByIdProductImageDto, UpdateProductImageDto>();

            CreateMap<GetByIdAboutDto, UpdateAboutDto>();

            CreateMap<GetByIdBrandDto, UpdateBrandDto>();

            CreateMap<GetByIdFeatureSliderDto, UpdateFeatureSliderDto>();

            CreateMap<GetByIdDiscountOfferDto, UpdateDiscountOfferDto>();

            CreateMap<GetByIdSpecialOfferDto, UpdateSpecialOfferDto>();
        }
    }
}
