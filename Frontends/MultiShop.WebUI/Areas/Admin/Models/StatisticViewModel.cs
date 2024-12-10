namespace MultiShop.WebUI.Areas.Admin.Models
{
    public class StatisticViewModel
    {
        public CatalogStatisticViewModel CatalogStatistics { get; set; }
        public UserStatisticViewModel UserStatistics { get; set; }
        public CommentStatisticViewModel CommentStatistics { get; set; }
        public DiscountStatisticViewModel DiscountStatistics { get; set; }
    }
}
