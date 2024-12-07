using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MultiShop.Core.Entities;

namespace MultiShop.Catalog.Entities
{
    public class SpecialOffer : MongoEntityBase
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
