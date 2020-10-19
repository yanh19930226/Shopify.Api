using AutoMapper;
using Shopify.Api.Abstractions.IntegrationEventModels.Orders;
using Shopify.Api.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Api.Application.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderAsyncModel, Order>();
        }
    }
}
