using Shopify.SDK.Models.Orders.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopify.SDK.Models.Orders.Request
{
    public class OrderByIdRequest : BaseRequest<OrderResponse>
    {
        public OrderByIdRequest(string url, string apikey, string apivalue) : base(url, apikey, apivalue)
        {

        }

        public string OrderId { get; set; }

        public override string CreateUrl()
        {
            return base.ApiUrl+"/admin/api/2020-10/orders/"+OrderId+".json";
        }
    }
}
