using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XShoppy.SDK
{
    public class XShoppyClient
    {
        //private readonly EnvEnum _envEnum;
        public XShoppyClient(/*EnvEnum envEnum*/)
        {
            //_envEnum = envEnum;
        }
        public Task<T> GetRequestAsync<T>(BaseRequest<T> request)
        {
            return $"{request.ApiUrl+request.CreateUrl()}"
                .WithBasicAuth(request.ApiKey, request.ApiValue)
                .WithHeader("X-SAIL-ACCESS-TOKEN", request.ShareKey)
                .GetAsync()
                .ReceiveJson<T>();
        }



        public Task<T> PostRequestAsync<T>(BaseRequest<T> request)
        {
            return $"{request.CreateUrl()}"
                .PostJsonAsync(request)
                .ReceiveJson<T>();
        }

        //private string GetApiBaseUrl()
        //{
        //    switch (_envEnum)
        //    {
        //        case EnvEnum.SandBox:
        //            return "http://gztest.glitzcloud.com/agent/v1/";
        //        case EnvEnum.Prod:
        //            return "https://ssl.glitzcloud.com/agent/v1/";
        //        default:
        //            return "http://gztest.glitzcloud.com/agent/v1/";
        //    }
        //}
    }
}
