using Core.Data.Domain.Interfaces;
using Core.EventBus.Abstractions;
using Core.Extensions;
using Shopify.Api.Application.IntegrationEvents.Orders;
using Shopify.Api.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Api.Application.IntegrationEventHandlers.Orders
{
    public class OrderAsyncIntegrationEventHandler : IIntegrationEventHandler<OrderAsyncIntegrationEvent>
    {

        private readonly IRepository<Order> _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderAsyncIntegrationEventHandler(IRepository<Order> orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(OrderAsyncIntegrationEvent @event)
        {
            foreach (var item in @event.EventData.list)
            {
                var order = _orderRepository.GetAll().Where(p => p.OrderNumber == item.OrderNumber && p.PlatformType == item.PlatformType&&p.ShopId==item.ShopId).FirstOrDefault();
                if (order!=null)
                {
                    order.ShopId = @event.EventData.ShopId;
                    _orderRepository.Update(item.MapTo<Order>());
                }
                else
                {
                    var newOrder = item.MapTo<Order>();
                    newOrder.ShopId = @event.EventData.ShopId;
                    _orderRepository.Add(newOrder);
                }
            }
            await _unitOfWork.CommitAsync();
        }
    }
}
