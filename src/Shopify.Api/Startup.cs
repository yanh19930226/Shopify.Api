using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Core;
using Core.Consul;
using Core.EventBus.Impletment.RabbitMq;
using Core.Logger;
using Core.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shopify.Api.Application.IntegrationEventHandlers.Orders;
using Shopify.Api.Application.IntegrationEvents.Orders;
using Shopify.Api.Services;
using Shopify.Api.Services.Impl;
using Shopify.SDK;
using XShoppy.SDK;

namespace Shopify.Api
{
    public class Startup : CommonStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        public override void CommonServices(IServiceCollection services)
        {
            //services.AddDbContext<ShopifyContext>(options =>
            //{
            //    options.UseMySql(Configuration.GetSection("Zeus:Connection").Value, sql => sql.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name));
            //});

            services.AddSingleton(new ShopifyClient());
            services.AddSingleton(new XShoppyClient());

            services
                 .AddSingleton(new HttpClient())
                       .AddScoped<IBasicApiService, BasicApiService>();
                       //.AddScoped<IShopOrderService, ShopifyOrderService>();

            services.AddCoreSeriLog()
                         .AddCoreSwagger()
                        .AddConsul()
                       .AddEventBus();
        }

        public override void CommonConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCoreSwagger()
                  .UseConsul()
                  .UseEventBus(eventBus =>
                  {
                       eventBus.Subscribe<OrderAsyncIntegrationEvent, OrderAsyncIntegrationEventHandler>();
                  });
        }
    }
}
