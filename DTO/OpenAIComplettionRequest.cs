using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;

namespace GPT3Wrapper.DTO
{
    public class OpenAICompletionRequest : IRequest<string>
    {

        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("prompt")]
        public string Prompt { get; set; }
        [JsonProperty("temperature")]
        public double Temperature { get; set; }
        [JsonProperty("max_tokens")]
        public int MaxTokens { get; set; }
        [JsonProperty("top_p")]
        public double TopP { get; set; }
        [JsonProperty("frequency_penalty")]
        public double FrequencyPenalty { get; set; }
        [JsonProperty("presence_penalty")]
        public double PresencePenalty { get; set; }

        [JsonProperty("stop")]
        public string[] Stop { get; set; }
       // public string BotType { get; set; }
    }
}
