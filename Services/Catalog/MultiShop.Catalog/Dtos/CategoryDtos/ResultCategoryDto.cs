using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Dtos.CategoryDtos;

public class ResultCategoryDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<ResultProductDto> Products { get; set; }
}
