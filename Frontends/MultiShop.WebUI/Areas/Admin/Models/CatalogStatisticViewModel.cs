namespace MultiShop.WebUI.Areas.Admin.Models
{
    public class CatalogStatisticViewModel
    {

        public long CategoryCount { get; set; }
        public long ProductCount { get; set; }
        public decimal ProductAvgPrice { get; set; }
        public long BrandCount { get; set; }
        public string MaxPriceProductName { get; set; }
        public string MinPriceProductName { get; set; }
    }
}
