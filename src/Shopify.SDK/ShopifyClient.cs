using Flurl.Http;
using Shopify.SDK.Models;
using System;
using System.Collections.Generic;
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
            var url = request.CreateUrl();
            return $"{request.CreateUrl()}"
                .GetAsync()
                .ReceiveJson<T>();
        }
        public Task<T> PostRequestAsync<T>(BaseRequest<T> request)
        {
            return $"{request.CreateUrl()}"
                .GetAsync()
                .ReceiveJson<T>();
        }
    }
}
