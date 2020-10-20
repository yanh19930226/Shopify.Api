using System;
using System.Collections.Generic;
using System.Text;

namespace XShoppy.SDK.Models.Orders
{
    public class OrderCountRequest : BaseRequest<BaseResponse<OrderCountResponse>>
    {
        public OrderCountRequest(string apiurl,string apikey, string apivalue,string sharekey) : base(apiurl,apikey, apivalue, sharekey)
        {

        }
        public DateTime time_start { get; set; }
        public DateTime time_end { get; set; }

        public override string CreateUrl()
        {
            return base.ApiUrl+"/order/orders/count";
        }
    }


    public class OrderCountResponse
    {
        public int count { get; set; }
    }
}
