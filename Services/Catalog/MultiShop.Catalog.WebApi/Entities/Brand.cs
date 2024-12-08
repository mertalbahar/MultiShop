using MultiShop.Core.Entities;

namespace MultiShop.Catalog.WebApi.Entities;

public class Brand : MongoEntityBase
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
}
