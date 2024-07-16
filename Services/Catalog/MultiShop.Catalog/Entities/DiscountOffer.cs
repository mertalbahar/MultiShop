using MultiShop.Core.Entities;

namespace MultiShop.Catalog.Entities
{
    public class DiscountOffer : MongoEntityBase
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
