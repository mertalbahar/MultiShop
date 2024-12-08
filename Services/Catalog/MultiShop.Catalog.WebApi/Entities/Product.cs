using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Core.Entities;

namespace MultiShop.Catalog.WebApi.Entities;

public class Product : MongoEntityBase
{
    public string CategoryId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }

    [BsonIgnore]
    public virtual Category? Category { get; set; }
}
