﻿namespace MultiShop.Discount.WebApi.Entities;

public class Coupon
{
    public int Id { get; set; }
    public string Code { get; set; }
    public int Rate { get; set; }
    public bool Status { get; set; }
    public DateTime ValidDate { get; set; }
}