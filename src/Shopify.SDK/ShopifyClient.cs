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
            return $"{request.CreateUrl()}".WithBasicAuth("cf9a3d10c7b1ffcf49fc23d900b64e17", "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").GetAsync().ReceiveJson<T>();
        }
        public Task<T> PostRequestAsync<T>(BaseRequest<T> request)
        {
            return $"{request.CreateUrl()}"
                .GetAsync()
                .ReceiveJson<T>();
        }
    }
}
