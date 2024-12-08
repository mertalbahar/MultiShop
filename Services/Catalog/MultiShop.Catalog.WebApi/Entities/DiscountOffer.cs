﻿using MultiShop.Core.Entities;

namespace MultiShop.Catalog.WebApi.Entities
{
    public class DiscountOffer : MongoEntityBase
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
