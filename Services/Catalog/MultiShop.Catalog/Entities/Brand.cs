using MultiShop.Core.Entities;

namespace MultiShop.Catalog.Entities;

public class Brand : MongoEntityBase
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
}