using AutoMapper;
using Basic.Api.Abstractions.Enums;
using Shopify.Api.Abstractions.IntegrationEventModels.Orders;
using Shopify.Api.Models.Domain;
using Shopify.SDK.Models.Orders.Response;
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

            //Shopify
            CreateMap<OrderModel, OrderAsyncModel>()
                .ForMember(p => p.PlatformType, src => src.MapFrom(p => (int)PlatformType.Shopify))
                .ForMember(p => p.PlatformOrderId, src => src.MapFrom(p => p.id))
                .ForMember(p => p.Email, src => src.MapFrom(p => p.email))
               .ForMember(p => p.OrderCloseTime, src => src.MapFrom(p => p.closed_at))
               .ForMember(p => p.OrderCreateTime, src => src.MapFrom(p => p.created_at))
                .ForMember(p => p.Phone, src => src.MapFrom(p => p.phone))
               .ForMember(p => p.OrderUpdateTime, src => src.MapFrom(p => p.updated_at))
               .ForMember(p => p.OrderNumber, src => src.MapFrom(p => p.number))
                .ForMember(p => p.Note, src => src.MapFrom(p => p.note))
               .ForMember(p => p.Currency, src => src.MapFrom(p => p.currency))
               .ForMember(p => p.TotalPrice, src => src.MapFrom(p => p.total_price))
                .ForMember(p => p.FinancialStatus, src => src.MapFrom(p => p.financial_status))
               .ForMember(p => p.FulfillmentStatus, src => src.MapFrom(p => p.fulfillment_status))
               .ForMember(p => p.LandingSite, src => src.MapFrom(p => p.landing_site))
               .ForMember(p => p.TotalPriceUsd, src => src.MapFrom(p => p.total_price_usd));


            //Xshopp
            CreateMap<XShoppy.SDK.Models.Orders.OrderModel, OrderAsyncModel>()
                 .ForMember(p => p.PlatformType, src => src.MapFrom(p => (int)PlatformType.XShoppy))
                .ForMember(p => p.PlatformOrderId, src => src.MapFrom(p => p.id))
                .ForMember(p => p.Email, src => src.MapFrom(p => p.email))
               .ForMember(p => p.OrderCloseTime, src => src.MapFrom(p => p.updated_at))
               .ForMember(p => p.OrderCreateTime, src => src.MapFrom(p => p.created_at))
                .ForMember(p => p.Phone, src => src.MapFrom(p =>p.email))
               .ForMember(p => p.OrderUpdateTime, src => src.MapFrom(p => p.updated_at))
               .ForMember(p => p.OrderNumber, src => src.MapFrom(p => p.order_number))
                .ForMember(p => p.Note, src => src.MapFrom(p => p.note))
               .ForMember(p => p.Currency, src => src.MapFrom(p => p.currency))
               .ForMember(p => p.TotalPrice, src => src.MapFrom(p => p.total_price))
                .ForMember(p => p.FinancialStatus, src => src.MapFrom(p => p.financial_status))
               .ForMember(p => p.FulfillmentStatus, src => src.MapFrom(p => p.fulfillment_status))
               .ForMember(p => p.LandingSite, src => src.MapFrom(p => p.landing_site))
               .ForMember(p => p.TotalPriceUsd, src => src.MapFrom(p => p.total_price));
        }
    }
}
