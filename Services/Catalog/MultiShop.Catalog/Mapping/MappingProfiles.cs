﻿using AutoMapper;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.DiscountOfferDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, ResultCategoryDto>().ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products)).ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

        CreateMap<Product, ResultProductDto>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name)).ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, GetByIdProductDto>().ReverseMap();

        CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();

        CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
        CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
        CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
        CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();

        CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
        CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
        CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
        CreateMap<FeatureSlider, GetByIdFeatureSliderDto>().ReverseMap();
        
        CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
        CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
        CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();
        CreateMap<SpecialOffer, GetByIdSpecialOfferDto>().ReverseMap();

        CreateMap<DiscountOffer, ResultDiscountOfferDto>().ReverseMap();
        CreateMap<DiscountOffer, CreateDiscountOfferDto>().ReverseMap();
        CreateMap<DiscountOffer, UpdateDiscountOfferDto>().ReverseMap();
        CreateMap<DiscountOffer, GetByIdDiscountOfferDto>().ReverseMap();

        CreateMap<Brand, ResultBrandDto>().ReverseMap();
        CreateMap<Brand, CreateBrandDto>().ReverseMap();
        CreateMap<Brand, UpdateBrandDto>().ReverseMap();
        CreateMap<Brand, GetByIdBrandDto>().ReverseMap();

        CreateMap<About, ResultAboutDto>().ReverseMap();
        CreateMap<About, CreateAboutDto>().ReverseMap();
        CreateMap<About, UpdateAboutDto>().ReverseMap();
        CreateMap<About, GetByIdAboutDto>().ReverseMap();
    }
}
