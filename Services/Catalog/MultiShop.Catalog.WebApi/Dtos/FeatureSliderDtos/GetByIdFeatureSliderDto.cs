﻿namespace MultiShop.Catalog.WebApi.Dtos.FeatureSliderDtos
{
    public class GetByIdFeatureSliderDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}