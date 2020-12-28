using Business.IServices;
using Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICouponService couponService;

        public HomeController(ICouponService _couponService)
        {
            couponService = _couponService;
        }

        public IActionResult Index()
        {
            var coupons = couponService.GetCoupons();

            return View(coupons);
        }

        [HttpPost]
        public bool CheckCode(string code)
        {
            var result = couponService.CheckCode(code);

            return result;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
