using AutoMapper;
using Core.Data.Domain.CommandHandlers;
using Core.Data.Domain.Interfaces;
using Core.EventBus.Abstractions;
using MediatR;
using Shopify.Api.Abstractions.Enums;
using Shopify.Api.Abstractions.IntegrationEventModels.Orders;
using Shopify.Api.Application.Commands.Orders;
using Shopify.Api.Application.IntegrationEvents.Orders;
using Shopify.Api.Services;
using Shopify.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shopify.Api.Application.CommandHandlers.Orders
{
    public class OrderAsyncCommandHandler : CommandHandler, IRequestHandler<OrderAsyncCommand, bool>
    {
        private readonly IBasicApiService _basicApiService;

        private readonly IShopOrderService _shopOrderService;

        private readonly IMapper _mapper;

        private readonly IEventBus _eventBus;
        public OrderAsyncCommandHandler(IUnitOfWork uow, IBasicApiService basicApiService, IShopOrderService shopOrderService, IMapper mapper, IEventBus eventBus) : base(uow)
        {
            _basicApiService = basicApiService;
            _shopOrderService = shopOrderService;
            _mapper = mapper;
            _eventBus = eventBus;
        }
        public async Task<bool> Handle(OrderAsyncCommand request, CancellationToken cancellationToken)
        {
            var shops = await _basicApiService.GetAllShop();
            foreach (var item in shops)
            {
                var platformType = item.Types == (int)PlatformType.Shopify ? (int)PlatformType.Shopify : (int)PlatformType.XShoppy;
                //店铺订单
                var shopOrderList = await _shopOrderService.GetOrderList(item);
                var eventModel = new OrderAsyncIntegrationEventModel();
                foreach (var order in shopOrderList.orders)
                {
                    OrderAsyncModel add = new OrderAsyncModel
                    {
                        PlatformType = platformType,
                        PlatformId = order.id,
                        Email = order.email,
                        OrderCloseTime = order.closed_at,
                        OrderUpdateTime = order.updated_at,
                        OrderCreateTime = order.created_at,
                        Phone = order.phone,
                        OrderNumber = order.number,
                        Note = order.note,
                        Currency = order.currency,
                        TotalPrice = order.total_price,
                        FinancialStatus = order.financial_status,
                        FulfillmentStatus = order.fulfillment_status,
                        LandingSite = order.landing_site,
                        Name = order.name,
                        TotalPriceUsd = order.total_price_usd
                    };
                    eventModel.list.Add(add);
                }
                _eventBus.Publish(new OrderAsyncIntegrationEvent(eventModel));
            }
            return await CommitAsync();
        }
    }
}
