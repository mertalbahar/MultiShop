﻿namespace MultiShop.DtoLayer.DiscountDtos;

public class CreateDiscountCouponDto
{
    public string Code { get; set; }
    public int Rate { get; set; }
    public bool Status { get; set; }
    public DateTime ValidDate { get; set; }
}
