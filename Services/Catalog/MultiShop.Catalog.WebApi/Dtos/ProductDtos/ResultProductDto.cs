﻿namespace MultiShop.Catalog.WebApi.Dtos.ProductDtos;

public class ResultProductDto
{
    public string Id { get; set; }
    public string CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}
