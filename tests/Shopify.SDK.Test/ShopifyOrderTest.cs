using Shopify.SDK.Models.Orders;
using Shopify.SDK.Models.Orders.Request;
using Shopify.SDK.Models.Orders.Response;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Shopify.SDK.Test
{
    public class ShopifyOrderTest
    {
        private ShopifyClient _client;

        #region Shop
        private string ApiUrl = "https://c2afe34ad1ee8bf6372e0c16bf11262f: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@rtocty.myshopify.com";

        private string apikey = "c2afe34ad1ee8bf6372e0c16bf11262f";

        private string apivalue = "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"; 
        #endregion

        public ShopifyOrderTest()
        {
            _client = new ShopifyClient();
        }
        /// <summary>
        /// 获取所有订单
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetOrderList()
        {
            var res = await _client.GetRequestAsync<OrderListResponse>(new OrderRequest(ApiUrl, apikey, apivalue) { 
                 created_at_min=DateTime.Now.AddHours(-6),
                 created_at_max=DateTime.Now
            });
            Assert.True(res.orders.Count > 0);
        }
        /// <summary>
        /// 条件获取订单
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetOrderListByCondition()
        {
            var res = await _client.GetRequestAsync<OrderListResponse>(new OrderConditionRequest (ApiUrl, apikey, apivalue)
            {
                created_at_max=DateTime.Now,
                created_at_min=DateTime.Now.AddDays(-30),
                status="any"
            });
            Assert.True(res.orders.Count > 0);
        }
        /// <summary>
        /// 获取订单数
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetOrderListCount()
        {
            var res = await _client.GetRequestAsync<OrderCountResponse>(new OrderCountRequest(ApiUrl, apikey, apivalue));
            Assert.True(res.count>0);
        }
        /// <summary>
        /// 获取特定订单
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetOrderByOrderId()
        {
            var res = await _client.GetRequestAsync<OrderResponse>(new OrderByIdRequest(ApiUrl, apikey, apivalue)
            {
               OrderId= "2596555685993"
            });
            Assert.True(res.order.id!="");
        }
    }
}
