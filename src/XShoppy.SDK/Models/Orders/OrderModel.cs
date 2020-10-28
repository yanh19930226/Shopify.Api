using System;
using System.Collections.Generic;
using System.Text;

namespace XShoppy.SDK.Models.Orders
{
    public class OrderModel
    {
        public string shop_url { set; get; }
        public string id { set; get; }
        public string browser_ip { set; get; } = "";
        public string note { set; get; } = "";
        public string customer_id { set; get; }
        public string shipping_method { set; get; }
        public string email { set; get; }
        public string gateway { set; get; }
        public Decimal total_price { set; get; }
        public Decimal subtotal_price { set; get; }
        public string total_weight { set; get; }
        public string currency { set; get; }
        public string financial_status { set; get; }
        public string fulfillment_status { set; get; }

        public string landing_site { set; get; }

        public string order_number { set; get; }
        public string order_name { set; get; }
        public DateTime pay_time { set; get; }
        public DateTime updated_at { set; get; }
        public string created_at { set; get; }
        public string transaction_id { set; get; }
        public string order_status_url { set; get; }
        public string checkout_id { set; get; }
    }
}
