using System;
using System.Collections.Generic;
using System.Text;

namespace XShoppy.SDK.Models.Orders
{
    public class OrderListRequest : BaseRequest<BaseResponse<OrderListPageResponse>>
    {
        public OrderListRequest(string apikey, string apivalue, string sharekey) : base(apikey, apivalue, sharekey)
        {

        }
        public DateTime time_start { get; set; }
        public DateTime time_end { get; set; }
        ///// <summary>
        ///// 订单状态
        ///// </summary>
        //public string status { get; set; }
        ///// <summary>
        ///// 支付状态
        ///// </summary>
        //public string financial_status { get; set; }
        /// <summary>
        /// 第几页数据
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 每页数据条数
        /// </summary>
        public int limit { get; set; }

        public override string CreateUrl()
        {
            return "/order/orders/list?limit="+this.limit+ "&page="+this.page+ "&time_start="+ TimeStampConvert.ToLong(time_start)+ "&time_end="+ TimeStampConvert.ToLong(time_end);
        }
    }

    public class OrderListPageResponse
    {
        public int totalCount { get; set; }
        public int currentPage { get; set; }

        public int limit { get; set; }

        public List<OrderModel> data { get; set; }

    }

    // <summary>
    /// DateTime时间格式转换为Unix时间戳格式(int类型)
    /// </summary>
    public static class TimeStampConvert
    {

        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(int timeStamp)
        {
            DateTime dateTimeStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp.ToString() + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);

            return dateTimeStart.Add(toNow);
        }

        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ToLong(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (long)(time - startTime).TotalSeconds;
        }

    }


}
