using Core.Data.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Api.Models.Domain
{
    public class Order : Entity
    {
        /// <summary>
        /// 平台类型
        /// </summary>
        public int PlatformType { get; set; }
        /// <summary>
        /// 平台Id
        /// </summary>
        public string PlatformId { get; set; }
        /// <summary>
        /// 邮件
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 订单关闭时间
        /// </summary>
        public string OrderCloseTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string OrderCreateTime { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public string OrderUpdateTime { get; set; }
        /// <summary>
        /// OrderNumber
        /// </summary>
        public int OrderNumber { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        ///使用币种
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 所有订单项价格，折扣，运费，税费和商店货币小费的总和
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 履行状态
        /// </summary>
        public string FinancialStatus { get; set; }
        /// <summary>
        /// 物流状态
        /// </summary>
        public string FulfillmentStatus { get; set; }
        /// <summary>
        /// 来源URl
        /// </summary>
        public string LandingSite { get; set; }
        /// <summary>
        /// order_number 客服和客户看的id
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// TotalPriceUsd
        /// </summary>
        public decimal TotalPriceUsd { get; set; }
    }
}
