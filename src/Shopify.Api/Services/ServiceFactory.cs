using AutoMapper;
using Basic.Api.Abstractions.Enums;
using Shopify.Api.Services.Impl;
using Shopify.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XShoppy.SDK;

namespace Shopify.Api.Services
{
    public  class ServiceFactory
    {
        public ServiceFactory()
        {
           
        }
        public static IShopOrderService CreateOrderService(PlatformType type)
        {
            IShopOrderService orderService = null;
            switch (type)
            {
                case PlatformType.Shopify:
                    orderService = new ShopifyOrderService(new ShopifyClient());
                    break;
                case PlatformType.XShoppy:
                    orderService = new XShoppyOrderService(new XShoppyClient());
                    break;
                default:
                    break;
            }
            return orderService;
        }
    }
}
