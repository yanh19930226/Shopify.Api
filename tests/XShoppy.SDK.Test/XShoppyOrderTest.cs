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
        /// ����Id��ȡ����
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
        /// ��ȡ���ж�������
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetOrderCount()
        {
            var res = await _client.GetRequestAsync(new OrderCountRequest(apikey, apivalue,sharekey));
            Assert.True(res.code==0);
        }
        /// <summary>
        /// ��ȡ�����б�
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
        /// ��Unixʱ���ת��ΪDateTime����ʱ��
        /// </summary>
        /// <param name="d">double ������</param>
        /// <returns>DateTime</returns>
        public static System.DateTime ConvertIntDateTime(double d)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddMilliseconds(d);
            return time;
        }

        /// <summary>
        /// ��c# DateTimeʱ���ʽת��ΪUnixʱ�����ʽ
        /// </summary>
        /// <param name="time">ʱ��</param>
        /// <returns>long</returns>
        public static long ConvertDateTimeInt(System.DateTime time)
        {
            //double intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            //intResult = (time- startTime).TotalMilliseconds;
            long t = (time.Ticks - startTime.Ticks) / 10000;            //��10000����Ϊ13λ
            return t;
        }



    }
}
