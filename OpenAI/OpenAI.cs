using GPT3Wrapper.DTO;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace GPT3Wrapper.OpenAI
{
    public class OpenAI : IOpenAIClient
    {
        private readonly ILogger<OpenAI> _logger;

        public OpenAI()
        { }

        public OpenAI(ILogger<OpenAI> logger)
        {
            _logger = logger;
        }

        public async Task<string> CreateCompletion(OpenAICompletionRequest request, string key, CancellationToken token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");
                _logger.LogInformation("Fetching Open AI API");

                using (StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"))

                using (HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/completions", content, token))
                {
                    string responseString = await response.Content.ReadAsStringAsync();

                    _logger.LogInformation($"Response:{responseString}");
                    var chatGPT = System.Text.Json.JsonSerializer.Deserialize<GPTRoot>(responseString);

                    if (chatGPT != null)
                    {
                        if (chatGPT.choices != null)
                            return chatGPT.choices[0].text;
                        else
                            _logger.LogDebug($"ChatGPT.Choices is null");
                    }
                    else
                        _logger.LogDebug($"ChatGPT is null");
                }
            }

            return string.Empty;
        }
    }
}