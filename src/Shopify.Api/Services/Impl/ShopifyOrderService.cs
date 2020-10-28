using AutoMapper;
using Basic.Api.Abstractions.Dtos.Response.Shop;
using Core.Extensions;
using Shopify.Api.Abstractions.IntegrationEventModels.Orders;
using Shopify.SDK;
using Shopify.SDK.Models.Orders.Request;
using Shopify.SDK.Models.Orders.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Api.Services.Impl
{
    public class ShopifyOrderService: IShopOrderService
    {
        private ShopifyClient _client;
        public ShopifyOrderService(ShopifyClient client)
        {
            _client = client;
        }

        public async Task<List<OrderAsyncModel>> GetOrderList(ShopResponseDto shop, DateTime startTime, DateTime endTime)
        {
            var res =await _client.GetRequestAsync<OrderListResponse>(new OrderRequest(shop.ApiUrl, shop.ApiKey, shop.ApiKeyValue) { 
                   created_at_min= startTime,
                   created_at_max= endTime
            });
            return res.orders.MapTo<List<OrderAsyncModel>>();
        }

        public void GetOrderListByCondition()
        {

        }

        public void GetOrderListCount()
        {

        }

        public void GetOrderByOrderId()
        {

        }
    }
}
