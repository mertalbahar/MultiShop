using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Core.Entities;

namespace MultiShop.Catalog.Entities;

public class ProductImage : MongoEntityBase
{
    public string ProductId { get; set; }
    public string Image1 { get; set; }
    public string Image2 { get; set; }
    public string Image3 { get; set; }

    [BsonIgnore]
    public Product Product { get; set; }
}