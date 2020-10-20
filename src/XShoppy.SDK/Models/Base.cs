using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XShoppy.SDK
{
    public abstract class BaseRequest<T>
    {
        public BaseRequest(string apiurl,string apiKey, string apiValue,string shareKey)
        {
            this.ApiUrl = apiurl;
            this.ApiKey = apiKey;
            this.ApiValue = apiValue;
            this.ShareKey = shareKey;
        }
        public string ApiUrl { get; set; }
        public string ApiKey { get; set; }
        public string ApiValue { get; set; }

        public string ShareKey { get; set; }

        public abstract string CreateUrl();
    }

    public class BaseResponse<T>
    {
        public int code { get; set; }
        public string  msg { get; set; }
        public T data { get; set; }
    }


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
}
