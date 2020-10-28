using AutoMapper;
using Basic.Api.Abstractions.Dtos.Response.Shop;
using Basic.Api.Abstractions.Enums;
using Core.Data.Domain.CommandHandlers;
using Core.Data.Domain.Interfaces;
using Core.EventBus.Abstractions;
using MediatR;
using Shopify.Api.Abstractions.IntegrationEventModels.Orders;
using Shopify.Api.Application.Commands.Orders;
using Shopify.Api.Application.IntegrationEvents.Orders;
using Shopify.Api.Models.Domain;
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

        private  IRepository<Order> _orderRepository;

        private  IShopOrderService _shopOrderService=null;

        private readonly IEventBus _eventBus;
        public OrderAsyncCommandHandler(IUnitOfWork uow, IBasicApiService basicApiService, IRepository<Order> orderRepository, IEventBus eventBus) : base(uow)
        {
            _basicApiService = basicApiService;
            _orderRepository = orderRepository;
            _eventBus = eventBus;
        }
        public async Task<bool> Handle(OrderAsyncCommand request, CancellationToken cancellationToken)
        {
            var shops = await _basicApiService.GetAllShop();
            foreach (var item in shops)
            {
                var platformType = item.Types == (int)PlatformType.Shopify ? (int)PlatformType.Shopify : (int)PlatformType.XShoppy;

                if (item.Types == (int)PlatformType.Shopify)
                {
                    _shopOrderService=Services.ServiceFactory.CreateOrderService(PlatformType.Shopify);
                }
                if (item.Types == (int)PlatformType.XShoppy)
                {
                    _shopOrderService = Services.ServiceFactory.CreateOrderService(PlatformType.XShoppy);
                }
                //如果数据库的这种平台这个店铺的订单为0,获取全量订单,如果数据库这个种平台这个店铺的订单数不为0,获取增量订单
                var orders = _orderRepository.GetAll().Where(p => p.PlatformType == item.Types&&p.ShopId==item.Id);

                var shopOrderList = new List<OrderAsyncModel>();

                //增量订单
                if (orders.Any())
                {
                     shopOrderList = await _shopOrderService.GetOrderList(item,DateTime.Now.AddDays(-1),DateTime.Now);
                }
                else//全量订单
                {
                     shopOrderList = await _shopOrderService.GetOrderList(item, DateTime.Now.AddYears(-1), DateTime.Now);
                }
                var eventModel = new OrderAsyncIntegrationEventModel();
                eventModel.ShopId= item.Id;
                eventModel.list = shopOrderList;
                _eventBus.Publish(new OrderAsyncIntegrationEvent(eventModel));
            }
            return await CommitAsync();
        }
    }
}
