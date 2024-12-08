using MultiShop.Catalog.WebApi.Dtos.ProductDtos;

namespace MultiShop.Catalog.WebApi.Dtos.CategoryDtos;

public class ResultCategoryDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public List<ResultProductDto> Products { get; set; }
}
