﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderShippingAddressComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}