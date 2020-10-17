using Shopify.SDK.Models.Orders.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopify.SDK.Models.Orders.Request
{
    public class OrderRequest : BaseRequest<OrderListResponse>
    {
        public OrderRequest(string url, string apikey, string apivalue) : base(url, apikey, apivalue)
        {

        }
        public override string CreateUrl()
        {
            return base.ApiUrl+"/admin/api/2020-10/orders.json";
        }
    }
}
