using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shopify.Api.Application.Commands.Orders;

namespace Shopify.Api.Controllers
{

    /// <summary>
    ///订单
    /// </summary>
    [Route("Api/Order")]
    [ApiController]
    public class OrderController : Controller
    {

        private IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
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
             await _mediator.Send(command);
             return Ok();
        }
    }
}
