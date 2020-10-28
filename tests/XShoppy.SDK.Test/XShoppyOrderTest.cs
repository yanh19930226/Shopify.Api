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
                //time_start = ConvertDateTimeInt(DateTime.Now.AddDays(-3)),
                //time_end = ConvertDateTimeInt(DateTime.Now),
                page =1,
                limit=100
            }) ;
            Assert.True(res.code == 0);
        }


        /// <summary>
        /// 将Unix时间戳转换为DateTime类型时间
        /// </summary>
        /// <param name="d">double 型数字</param>
        /// <returns>DateTime</returns>
        public static System.DateTime ConvertIntDateTime(double d)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddMilliseconds(d);
            return time;
        }

        /// <summary>
        /// 将c# DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>long</returns>
        public static long ConvertDateTimeInt(System.DateTime time)
        {
            //double intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            //intResult = (time- startTime).TotalMilliseconds;
            long t = (time.Ticks - startTime.Ticks) / 10000;            //除10000调整为13位
            return t;
        }



    }
}
