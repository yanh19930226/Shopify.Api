using Shopify.SDK.Models.Orders;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Shopify.SDK.Test
{
    public class ShopifyClientTest
    {
        private ShopifyClient _client;

        public ShopifyClientTest()
        {
            _client = new ShopifyClient();
        }
        [Fact]
        public async Task GetOrderList()
        {
            var res = await _client.GetRequestAsync<OrderResponse>(new OrderRequest
            {
                created_at_min=DateTime.Now.AddDays(-10),
                created_at_max= DateTime.Now,
                status="any"
            });
            Assert.True(res.orders.Count > 0);
        }
    }
}
