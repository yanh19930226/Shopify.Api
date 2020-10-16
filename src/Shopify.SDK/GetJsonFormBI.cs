using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Shopify.SDK
{
    public class GetJsonFormBI
    {
        /// <summary>
        /// 获取BI接口的数据
        /// </summary>
        /// <param name="url">地址/控制/方法（参数）</param>
        /// <returns></returns>
        public String GetDatas(string url)
        {
            if (url != null)
            {

                HttpHelper _helper = new HttpHelper(url);
                _helper.Timeout = 0;
                using (var reader = _helper.OpenRead())
                {
                    using (var stream = new StreamReader(reader, Encoding.UTF8))
                    {
                        return (stream.ReadToEnd()); ;
                    }
                }
            }
            return null;
        }
        public static string RequestData(string POSTURL, string PostData)
        {
            //发送请求的数据

            WebRequest myHttpWebRequest = WebRequest.Create(POSTURL);
            myHttpWebRequest.Method = "POST";
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byte1 = encoding.GetBytes(PostData);
            myHttpWebRequest.ContentType = "application/form-data";
            myHttpWebRequest.ContentLength = byte1.Length;
            Stream newStream = myHttpWebRequest.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            newStream.Close();

            //发送成功后接收返回的XML信息
            HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.GetResponse();
            string lcHtml = string.Empty;
            Encoding enc = Encoding.GetEncoding("UTF-8");
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream, enc);
            lcHtml = streamReader.ReadToEnd();
            return lcHtml;
        }

    }
}
