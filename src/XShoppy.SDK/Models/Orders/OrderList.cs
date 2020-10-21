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
            return "/order/orders/list?limit="+this.limit+ "&page="+this.page;
        }
    }

    public class OrderListPageResponse
    {
        public int totalCount { get; set; }
        public int currentPage { get; set; }

        public int limit { get; set; }

        public List<OrderModel> data { get; set; }

    }
}
