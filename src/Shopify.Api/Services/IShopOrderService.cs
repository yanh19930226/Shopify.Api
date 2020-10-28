using Basic.Api.Abstractions.Dtos.Response.Shop;
using Shopify.Api.Abstractions.IntegrationEventModels.Orders;
using Shopify.SDK.Models.Orders.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Api.Services
{
    public interface IShopOrderService
    {
        Task<List<OrderAsyncModel>> GetOrderList(ShopResponseDto shop, DateTime startTime, DateTime endTime);
    }
}
