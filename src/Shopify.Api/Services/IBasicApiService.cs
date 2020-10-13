using Basic.Api.Abstractions.Dtos.Response.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Api.Services
{
    public interface IBasicApiService
    {
        /// <summary>
        /// 获取所有店铺
        /// </summary>
        /// <returns></returns>
        Task<List<ShopResponseDto>> GetAllShop();
    }
}
