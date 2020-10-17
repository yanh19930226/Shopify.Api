using Shopify.SDK.Models.Orders.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Api.Services
{
    public interface IShopOrderService
    {
        Task<OrderListResponse> GetOrderList();
    }
}
