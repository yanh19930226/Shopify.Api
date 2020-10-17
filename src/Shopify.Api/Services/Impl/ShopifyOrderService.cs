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

        public async Task<OrderListResponse> GetOrderList()
        {
            return  await _client.GetRequestAsync<OrderListResponse>(new OrderRequest(ApiUrl, apikey, apivalue));
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
