using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopify.SDK.Models.Orders.Response
{
    public class OrderListResponse
    {
        public List<OrderModel> orders { get; set; }
    }

    public class OrderResponse {
        public OrderModel order { get; set; }
    }

   
    public class OrderModel
    {
        /// <summary>
        /// api 内部ID
        /// </summary>
        public string id { get; set; }
        public string email { get; set; }
        public string closed_at { get; set; }
        public string updated_at { get; set; }
        public int number { get; set; }
        public string note { get; set; }
        public string token { get; set; }
        public string gateway { get; set; }
        public bool test { get; set; }
        /// <summary>
        /// 所有订单项价格，折扣，运费，税费和商店货币小费的总和
        /// </summary>
        public decimal total_price { get; set; }
        public string transaction_id { get; set; }
        public decimal subtotal_price { get; set; }
        /// <summary>
        /// 履行状态
        /// </summary>
        public string financial_status { get; set; }
        /// <summary>
        /// 物流状态
        /// </summary>
        public string fulfillment_status { get; set; }
        /// <summary>
        /// 来源URl
        /// </summary>
        public string landing_site { get; set; }

        public string location_id { get; set; }

        /// <summary>
        /// 使用语言
        /// </summary>
        public string customer_locale { get; set; }

        /// <summary>
        ///使用币种
        /// </summary>
        public string currency { get; set; }

        public string cart_token { get; set; }

        /// <summary>
        /// order_number 客服和客户看的id
        /// </summary>
        public string name { get; set; }

        public decimal total_price_usd { get; set; }

        public string browser_ip { get; set; }

        public string order_status_url { get; set; }
        /// <summary>
        /// tags
        /// </summary>
        public string tags { get; set; }

        public string created_at { get; set; }

        public string phone { get; set; }
    }
}
