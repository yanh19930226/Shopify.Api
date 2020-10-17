using Core.EventBus.Events;
using Shopify.Api.Abstractions.IntegrationEventModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Api.Application.IntegrationEvents.Orders
{
    public class OrderAsyncIntegrationEvent : IntegrationEvent<OrderAsyncIntegrationEventModel>
    {
        public OrderAsyncIntegrationEvent(OrderAsyncIntegrationEventModel eventData) : base(eventData)
        {
        }
    }
}
