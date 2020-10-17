using Core.EventBus.Abstractions;
using Shopify.Api.Application.IntegrationEvents.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Api.Application.IntegrationEventHandlers.Orders
{
    public class OrderAsyncIntegrationEventHandler : IIntegrationEventHandler<OrderAsyncIntegrationEvent>
    {
        public Task Handle(OrderAsyncIntegrationEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
