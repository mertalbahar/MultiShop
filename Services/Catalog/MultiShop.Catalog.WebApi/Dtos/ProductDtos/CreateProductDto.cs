﻿namespace MultiShop.Catalog.Dtos.ProductDtos;

public class CreateProductDto
{
    public string CategoryId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}
