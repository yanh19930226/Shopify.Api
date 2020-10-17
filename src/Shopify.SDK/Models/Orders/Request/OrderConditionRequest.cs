using Shopify.SDK.Models.Orders.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopify.SDK.Models.Orders.Request
{
    public class OrderConditionRequest : BaseRequest<OrderListResponse>
    {
        public OrderConditionRequest(string url, string apikey, string apivalue) : base(url, apikey, apivalue)
        {

        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime created_at_min { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime created_at_max { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string status { get; set; }
        public override string CreateUrl()
        {
            return base.ApiUrl+"/admin/api/2020-10/orders.json?status=" + this.status + "&created_at_min =" + this.created_at_min + "&created_at_max =" + this.created_at_max;
        }
    }
}
