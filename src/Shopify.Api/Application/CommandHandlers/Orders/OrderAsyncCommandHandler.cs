using Core.Data.Domain.CommandHandlers;
using Core.Data.Domain.Interfaces;
using Core.EventBus.Abstractions;
using MediatR;
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
        //private readonly IRepository<Company> _companyRepository;
        private readonly IBasicApiService _basicApiService;

        private readonly IShopOrderService _shopOrderService;

        private readonly IEventBus _eventBus;
        public OrderAsyncCommandHandler(IUnitOfWork uow, IBasicApiService  basicApiService, IShopOrderService shopOrderService, IEventBus eventBus) : base(uow)
        {
            //_companyRepository = companyRepository;
            _basicApiService = basicApiService;
            _shopOrderService = shopOrderService;
            _eventBus = eventBus;
        }
        public async Task<bool> Handle(OrderAsyncCommand request, CancellationToken cancellationToken)
        {
            var shops = await _basicApiService.GetAllShop();
            foreach (var item in shops)
            {
                var shopOrderList=_shopOrderService.GetOrderList();
                var eventModel = new OrderAsyncIntegrationEventModel()
                {

                };

                _eventBus.Publish(new OrderAsyncIntegrationEvent(eventModel));
            }
            throw new NotImplementedException();
        }
    }
}
