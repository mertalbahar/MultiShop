﻿namespace MultiShop.Catalog.WebApi.Settings;

public interface IDatabaseSettings
{
    public string CategoryCollectionName { get; set; }
    public string ProductCollectionName { get; set; }
    public string ProductDetailCollectionName { get; set; }
    public string ProductImageCollectionName { get; set; }
    public string FeatureSliderCollectionName { get; set; }
    public string SpecialOfferCollectionName { get; set; }
    public string DiscountOfferCollectionName { get; set; }
    public string BrandCollectionName { get; set; }
    public string AboutCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}