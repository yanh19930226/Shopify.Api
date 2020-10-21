using System;
using System.Threading.Tasks;
using XShoppy.SDK.Models.Orders;
using Xunit;

namespace XShoppy.SDK.Test
{
    public class XShoppyOrderTest
    {
        private XShoppyClient _client;

        private string apikey = "de757a56cae07088321f61142981b2e17c3b5723";

        private string apivalue = "c0e1860d295f405fbacdc299cc2dc2e4ab87094d";

        private string sharekey = "38be8fc30b98edbf57076612cf48f06b6bc0b9de";

        public XShoppyOrderTest()
        {
            _client = new XShoppyClient();
        }

        /// <summary>
        /// 订单Id获取订单
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetOrderById()
        {
            var res = await _client.GetRequestAsync(new OrderByIdRequest(apikey, apivalue, sharekey)
            {
                id = "201018105037101"
            }); 
            Assert.True(res.code == 0);
        }
        /// <summary>
        /// 获取所有订单数量
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetOrderCount()
        {
            var res = await _client.GetRequestAsync(new OrderCountRequest(apikey, apivalue,sharekey));
            Assert.True(res.code==0);
        }
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetOrderList()
        {
            var res = await _client.GetRequestAsync(new OrderListRequest(apikey, apivalue, sharekey)
            {
                //time_start = DateTime.Now,
                //time_end= DateTime.Now,
                page=1,
                limit=100
            }) ;
            Assert.True(res.code == 0);
        }

    }
}
