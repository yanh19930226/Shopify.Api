using Basic.Api.Abstractions.Dtos.Response.Shop;
using Core.ServiceDiscovery;
using Core.ServiceDiscovery.Impletment.LoadBalancer;
using Core.ServiceDiscovery.Impletment.Provider;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopify.Api.Services.Impl
{
    public class BasicApiService : IBasicApiService
    {
        private HttpClient _httpClient;
        private readonly ILogger<BasicApiService> _logger;
        public BasicApiService(HttpClient httpClient, ILogger<BasicApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<List<ShopResponseDto>> GetAllShop()
        {
            #region ServicesDiscovery
            var serviceProvider = new ConsulServiceProvider(new Uri("http://127.0.0.1:8500"));

            var Url = await serviceProvider.CreateServiceBuilder(builder =>
            {
                builder.ServiceName = "BasicApi";
                builder.LoadBalancer = TypeLoadBalancer.RandomLoad;
                builder.UriScheme = Uri.UriSchemeHttp;
            }).BuildAsync("/Api/Shop/GetShopList");
            #endregion
            try
            {
                var response = await _httpClient.GetAsync(Url);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<ShopResponseDto>>(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("在重试之后失败");
                throw new Exception(ex.Message);
            }
            return null;
        }
    }
}
