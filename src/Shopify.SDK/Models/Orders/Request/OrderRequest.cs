using Shopify.SDK.Models.Orders.Response;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Shopify.SDK.Models.Orders.Request
{
    public class OrderRequest : BaseRequest<OrderListResponse>
    {
        public OrderRequest(string url, string apikey, string apivalue) : base(url, apikey, apivalue)
        {
        }
        public DateTime created_at_min { get; set; }
        public DateTime created_at_max { get; set; }

        public override string CreateUrl()
        {

            //return base.ApiUrl + "/admin/api/2020-10/orders.json";

            return base.ApiUrl + "/admin/api/2020-10/orders.json?created_at_min=" + created_at_min.ToString("yyyy-MM-ddTHH:mm:sszzzz", DateTimeFormatInfo.InvariantInfo) + "&created_at_max=" + created_at_max.ToString("yyyy-MM-ddTHH:mm:sszzzz", DateTimeFormatInfo.InvariantInfo);
        }
    }
}
