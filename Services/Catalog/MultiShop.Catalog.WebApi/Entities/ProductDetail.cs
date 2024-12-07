using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Core.Entities;

namespace MultiShop.Catalog.Entities;

public class ProductDetail : MongoEntityBase
{
    public string ProductId { get; set; }
    public string Description { get; set; }
    public string Info { get; set; }

    [BsonIgnore]
    public Product Product { get; set; }
}
