using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPT3Wrapper.DTO;
using Microsoft.Extensions.Configuration;
using GPT3Wrapper.OpenAI;

namespace GPT3Wrapper.MediatR
{
    public class OpenAICompletionHandler
    {
        private readonly IOpenAIClient _openai;
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;

        public OpenAICompletionHandler(IOpenAIClient openai, IConfiguration configuration)
        {
            _openai = openai;
            _configuration = configuration;
            _apiKey = _configuration[$"OPENAPI_KEY"].ToString();
        }

        public async Task<string> Handle(OpenAICompletionRequest request, string botType, CancellationToken cancellationToken)
        {
            request.Model = _configuration[$"OpenAICompletion:{botType}:Model"];
            request.Temperature = double.Parse(_configuration[$"OpenAICompletion:{botType}:Temperature"]);
            request.MaxTokens = int.Parse(_configuration[$"OpenAICompletion:{botType}:MaxTokens"]);
            request.TopP = double.Parse(_configuration[$"OpenAICompletion:{botType}:TopP"]);
            request.FrequencyPenalty = double.Parse(_configuration[$"OpenAICompletion:{botType}:FrequencyPenalty"]);
            request.PresencePenalty = double.Parse(_configuration[$"OpenAICompletion:{botType}:PresencePenalty"]);
            //request.Stop = JsonConvert.DeserializeObject<string[]>(_configuration.GetSection("OpenAICompletion")[$"{botType}:Stop"]);
            request.Stop = _configuration.GetSection("OpenAICompletion:Chat:Stop").Get<string[]>();

            return await _openai.CreateCompletion(request, _apiKey, cancellationToken);
        }
    }
}