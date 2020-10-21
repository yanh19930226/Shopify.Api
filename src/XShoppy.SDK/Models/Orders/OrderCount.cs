using System;
using System.Collections.Generic;
using System.Text;

namespace XShoppy.SDK.Models.Orders
{
    public class OrderCountRequest : BaseRequest<BaseResponse<OrderCountResponse>>
    {
        public OrderCountRequest(string apikey, string apivalue,string sharekey) : base(apikey, apivalue, sharekey)
        {

        }
        public DateTime time_start { get; set; }
        public DateTime time_end { get; set; }

        public override string CreateUrl()
        {
            return "/order/orders/count";
        }
    }


    public class OrderCountResponse
    {
        public int count { get; set; }
    }
}
