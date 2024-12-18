﻿namespace MultiShop.Catalog.WebApi.Dtos.ProductImageDtos;

public class GetByIdProductImageDto
{
    public string Id { get; set; }
    public string ProductId { get; set; }
    public string Image1 { get; set; }
    public string Image2 { get; set; }
    public string Image3 { get; set; }
    public string ProductName { get; set; }
    public string ProductImageUrl { get; set; }
}
