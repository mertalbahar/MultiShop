using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Core.Entities;

namespace MultiShop.Catalog.WebApi.Entities;

public class Category : MongoEntityBase
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }

    [BsonIgnore]
    public virtual ICollection<Product> Products { get; set; }
}
