using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace GPT3Wrapper.Extensions
{
    public static class JSONExtensions
    {
        public static string FilterResponse(this string response)
        {
            var filter = response.Contains("Chatbot:") ? response.Replace("Chatbot:", "") : response;
            var filter2 = filter.Contains("ChatBot:") ? filter.Replace("ChatBot:", "") : filter;

            filter2 = filter2.Trim().Replace("\r\n", " \r\n ");
            filter2 = filter2.Replace("\n", " \n ");

            return filter2;
        }

        public static string ToJsonProperty<T>(this T[] arr, string propertyName)
        {
            var jsonProperty = new JsonObject();
            jsonProperty.Add(propertyName, JsonConvert.SerializeObject(arr));
            return jsonProperty.ToString();
        }

        public static string EscapeJSON(this string prompt)
        {
            var jsonObject = new { prompt };
            var jsonString = JsonConvert.SerializeObject(jsonObject);
            return jsonString.ToString();
        }
    }
}