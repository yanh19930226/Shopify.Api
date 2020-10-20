using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Domain.Bus;
using Core.EventBus.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopify.Api.Abstractions.IntegrationEventModels.Orders;
using Shopify.Api.Application.Commands.Orders;
using Shopify.Api.Application.IntegrationEvents.Orders;

namespace Shopify.Api.Controllers
{
    /// <summary>
    ///订单
    /// </summary>
    [Route("Api/Order")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IMediatorHandler _bus;
        private readonly IEventBus _eventBus;
        public OrderController(IMediatorHandler bus, IEventBus eventBus)
        {
            _bus = bus;
            _eventBus = eventBus;
        }
        /// <summary>
        /// 订单同步
        /// </summary>
        /// <returns></returns>
        [Route("OrderAsync")]
        [HttpGet]
        public async Task<IActionResult> OrderAsync()
        {
             var command = new OrderAsyncCommand();
             await _bus.SendCommandAsync(command);
             return Ok();
        }
    }
}
