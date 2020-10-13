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
            return $"{request.CreaeUrl()}"
                 .GetAsync()
                .ReceiveJson<T>();
        }
        public Task<T> PostRequestAsync<T>(BaseRequest<T> request)
        {
            return $"{request.CreaeUrl()}"
                 .GetAsync()
                .ReceiveJson<T>();
        }
    }
}
