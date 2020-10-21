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
    public class ServiceFactory
    {
        private static XShoppyClient _xclient;

        private static ShopifyClient _sclient;
        private   IServiceProvider _serviceProvider;
        public ServiceFactory(IServiceProvider provider, XShoppyClient xclient, ShopifyClient sclient)
        {
            _serviceProvider = provider;
            _xclient = xclient;
            _sclient = sclient;
        }
        public  static IShopOrderService CreateOrderService(PlatformType type)
        {
            IShopOrderService orderService = null;
            switch (type)
            {
                case PlatformType.Shopify:
                    orderService = new ShopifyOrderService(_sclient);
                    break;
                case PlatformType.XShoppy:
                    orderService = new XShoppyOrderService(_xclient);
                    break;
                default:
                    break;
            }
            return orderService;
        }
    }
}
