namespace MultiShop.Discount.WebApi.Dtos;

public class ResultDiscountCouponDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public int Rate { get; set; }
    public bool Status { get; set; }
    public DateTime ValidDate { get; set; }
}
