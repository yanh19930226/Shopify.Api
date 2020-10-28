using AutoMapper;
using Basic.Api.Abstractions.Dtos.Response.Shop;
using Core.Extensions;
using Shopify.Api.Abstractions.IntegrationEventModels.Orders;
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
        public async Task<List<OrderAsyncModel>> GetOrderList(ShopResponseDto shop,DateTime startTime,DateTime endTime)
        {
            var list = new List<OrderAsyncModel>();
            for (int page = 1; ; page++)
            {
                var res = await _client.GetRequestAsync(new OrderListRequest(shop.ApiKey, shop.ApiKeyValue, shop.ShareKey)
                {
                    page = page,
                    limit = 100,
                    time_start = startTime,
                    time_end = endTime
                });

                if (res.data.data.Count==0)
                {
                    break;
                }
                list.AddRange(res.data.data.MapTo<List<OrderAsyncModel>>());
            }
            return list;
        }
    }
}
