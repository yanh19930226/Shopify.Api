using System;
using System.Threading.Tasks;
using XShoppy.SDK.Models.Orders;
using Xunit;

namespace XShoppy.SDK.Test
{
    public class XShoppyOrderTest
    {
        private XShoppyClient _client;

        private string ApiUrl = "https://5ab2eea6cec93b40ecec4a82cdb9e275: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@gvabnck.myshopify.com";

        private string apikey = "5ab2eea6cec93b40ecec4a82cdb9e275";

        private string apivalue = "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";

        private string sharekey = "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";

        public XShoppyOrderTest(XShoppyClient client)
        {
            _client = client;
        }
        /// <summary>
        /// 获取所有订单
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetOrderCount()
        {
            var res = await _client.GetRequestAsync(new OrderCountRequest(ApiUrl, apikey, apivalue,sharekey));
            Assert.True(res.code==0);
        }
    }
}
