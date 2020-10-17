using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Shopify.Api.Controllers
{
    public class OrderController : Controller
    {
        /// <summary>
        /// 订单同步
        /// </summary>
        /// <returns></returns>
        public IActionResult OrderAsync()
        {


            return View();
        }
    }
}
