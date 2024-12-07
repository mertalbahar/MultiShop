using AutoMapper;
using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.DiscountOfferDtos;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.DtoLayer.CommentDtos.ContactDtos;
using MultiShop.DtoLayer.CommentDtos.UserCommentDtos;
using MultiShop.DtoLayer.DiscountDtos;
using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Infrastructures.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Catalog Microservice
            CreateMap<GetByIdCategoryDto, UpdateCategoryDto>();

            CreateMap<GetByIdProductDto, UpdateProductDto>();
            CreateMap<GetByIdProductDetailDto, UpdateProductDetailDto>();
            CreateMap<GetByIdProductImageDto, UpdateProductImageDto>();

            CreateMap<GetByIdAboutDto, UpdateAboutDto>();

            CreateMap<GetByIdBrandDto, UpdateBrandDto>();

            CreateMap<GetByIdFeatureSliderDto, UpdateFeatureSliderDto>();

            CreateMap<GetByIdDiscountOfferDto, UpdateDiscountOfferDto>();

            CreateMap<GetByIdSpecialOfferDto, UpdateSpecialOfferDto>();

            // Comment Microservice
            CreateMap<GetByIdUserCommentDto, UpdateUserCommentDto>();

            CreateMap<GetByIdContactDto, UpdateContactDto>();

            // Discount Microservice
            CreateMap<GetByIdDiscountCouponDto, UpdateDiscountCouponDto>();

            // Message Microservice
            CreateMap<GetByIdUserMessageDto, UpdateUserMessageDto>();

            // Cargo Microservice
            CreateMap<GetByIdCargoCompanyDto, UpdateCargoCompanyDto>();
        }
    }
}
