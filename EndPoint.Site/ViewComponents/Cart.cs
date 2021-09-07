using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Mvc;
using MyStore.Application.Services.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndPoint.Site.ViewComponents
{
    public class Cart:ViewComponent
    {
        ICartService _cartService;
        CookiesManager _cookiesManager;
        public Cart(ICartService cartService)
        {
            _cookiesManager = new CookiesManager();
            _cartService = cartService;
        }

        public IViewComponentResult Invoke()
        {
            var userId = ClaimUtility.GetUserId(HttpContext.User);
            return View("Cart",_cartService.GetMyCart(userId, _cookiesManager.GetBrowserID(HttpContext)).Data);
            
        }
    }
}
