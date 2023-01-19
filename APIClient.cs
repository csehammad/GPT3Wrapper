using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GPT3Wrapper
{
    public class APIClient
    {
        public APIClient() { }

        public static async Task<string>   InvokeAPI(string prompt,string apiKey,int maxTokens, float temperature,int top_p,float frequence_p,float presence_p,string stopSequence,string engine)
        {
           // string model = "text-davinci-003";

            string requestBody = $"{{\"model\": \"{engine}\", \"prompt\": \"{prompt}\", \"temperature\": {temperature}, \"top_p\": {top_p},  \"frequency_penalty\": {frequence_p}, \"presence_penalty\": {presence_p},   \"stop\": \'[ {presence_p} ]\', \"max_tokens\": {maxTokens}}}";

            using (HttpClient client = new HttpClient())
            {
                //  client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                using (StringContent content = new StringContent(requestBody, Encoding.UTF8, "application/json"))
                {
                    using (HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/completions", content))
                    {
                        // Read the response and do something with it
                        string responseString = await response.Content.ReadAsStringAsync();

                        var chatGPT = JsonSerializer.Deserialize<GPTRoot>(responseString);


                         if (chatGPT != null)
                        {
                            if (chatGPT.choices != null)
                                return chatGPT.choices[0].text;

                        }


                    }
                }

                return string.Empty;


            }


        }



    }
}
