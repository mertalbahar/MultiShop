﻿namespace MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

public class UpdateProductImageDto
{
    public string Id { get; set; }
    public string ProductId { get; set; }
    public string Image1 { get; set; }
    public string Image2 { get; set; }
    public string Image3 { get; set; }
    public string ProductName { get; set; }
}
