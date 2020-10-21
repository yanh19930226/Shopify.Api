using System;
using System.Collections.Generic;
using System.Text;

namespace XShoppy.SDK.Models.Orders
{
    public class OrderByIdRequest : BaseRequest<BaseResponse<OrderModel>>
    {
        public OrderByIdRequest(string apikey, string apivalue, string sharekey) : base(apikey, apivalue, sharekey)
        {

        }
        public string id { get; set; }

        public override string CreateUrl()
        {
            return "/order/orders?id="+this.id;
        }
    }
}
