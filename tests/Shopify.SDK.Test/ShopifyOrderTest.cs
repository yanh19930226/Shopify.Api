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
            var ApiUrl = "https://cf9a3d10c7b1ffcf49fc23d900b64e17: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@linsdcz.myshopify.com";
            var res = await _client.GetRequestAsync<OrderListResponse>(new OrderRequest(ApiUrl));
            Assert.True(res.orders.Count > 0);
        }
        /// <summary>
        /// 条件获取订单
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetOrderListByCondition()
        {
            var ApiUrl = "https://5ab2eea6cec93b40ecec4a82cdb9e275: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@gvabnck.myshopify.com/";
            var res = await _client.GetRequestAsync<OrderListResponse>(new OrderConditionRequest (ApiUrl)
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
            var ApiUrl = "https://5ab2eea6cec93b40ecec4a82cdb9e275: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@gvabnck.myshopify.com/";
            var res = await _client.GetRequestAsync<string>(new OrderCountRequest(ApiUrl));
            Assert.True(res!="");
        }
        /// <summary>
        /// 获取特定订单
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetOrderByOrderId()
        {
            var ApiUrl = "https://5ab2eea6cec93b40ecec4a82cdb9e275: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@gvabnck.myshopify.com/";
            var res = await _client.GetRequestAsync<OrderResponse>(new OrderByIdRequest(ApiUrl)
            {
               OrderId=""
            });
            Assert.True(res.order.id!="");
        }
    }
}
