using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopify.SDK.Models
{
    public abstract class BaseRequest<T>
    {
        public BaseRequest(string url,string apiKey,string apiValue)
        {
            this.ApiUrl = url;
            this.ApiKey = apiKey;
            this.ApiValue = apiValue;
        }
        public string ApiKey { get; set; }
        public string ApiValue { get; set; }

        public string ApiUrl { get; set; }//抽象属性
        public abstract string CreateUrl();
    }

    #region MyRegion
    public class DataConvert : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                var result = serializer.Deserialize(reader);

                if (result.ToString() == "[]")
                    return null;

                return JsonConvert.DeserializeObject(result.ToString(), objectType);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Console.WriteLine(111);
        }
    } 
    #endregion
}
