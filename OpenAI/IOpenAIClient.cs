using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPT3Wrapper.DTO;

namespace GPT3Wrapper.OpenAI
{
    public interface IOpenAIClient
    {
        Task<string> CreateCompletion(OpenAICompletionRequest request,string key, CancellationToken token);
    }


}
