using Basic.Api.Abstractions.Dtos.Response.Shop;
using Shopify.SDK.Models.Orders.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XShoppy.SDK;
using XShoppy.SDK.Models.Orders;

namespace Shopify.Api.Services.Impl
{
    public class XShoppyOrderService : IShopOrderService
    {
        private XShoppyClient _client;
        public XShoppyOrderService(XShoppyClient client)
        {
            _client = client;
        }
        public async Task<OrderListResponse> GetOrderList(ShopResponseDto shop)
        {

            for (int page = 1; ; page++)
            {
                var res = await _client.GetRequestAsync(new OrderListRequest(shop.ApiKey, shop.ApiKeyValue, shop.ShareKey)
                {
                    page = page,
                    limit = 100,
                    //time_start = DateTime.Now,
                    //time_end = DateTime.Now
                });
                if (res.data.data.Count==0)
                {
                    break;
                }
            }
            return null;
        }
    }
}
