using Flurl.Http;
using Shopify.SDK.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shopify.SDK
{
    public class ShopifyClient
    {
        public ShopifyClient()
        {
            
        }
        public Task<T> GetRequestAsync<T>(BaseRequest<T> request)
        {
            return $"{request.CreateUrl()}".WithBasicAuth(request.ApiKey, request.ApiValue).GetAsync().ReceiveJson<T>();
        }
        public Task<T> PostRequestAsync<T>(BaseRequest<T> request)
        {
            return $"{request.CreateUrl()}"
                .PostJsonAsync(request)
                .ReceiveJson<T>();
        }
    }
}
