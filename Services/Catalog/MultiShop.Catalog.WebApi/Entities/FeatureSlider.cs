using MultiShop.Core.Entities;

namespace MultiShop.Catalog.WebApi.Entities
{
    public class FeatureSlider : MongoEntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
