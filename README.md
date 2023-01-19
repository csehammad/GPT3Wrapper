# GPT3Wrapper
Open AI API Wrapper for .NET 7 (Generated using GPT3)


## Add appsettings.json 

  "OPENAPI_KEY": "OPEN_API_KEY_GOES_HERE",
##
You also need to define below parameters for different language models and their settings. 
```json
  "OpenAICompletion": {
    "Chat": {
      "Model": "text-davinci-003",
      "Temperature": 0.9,
      "MaxTokens": 150,
      "TopP": 1,
      "FrequencyPenalty": 0,
      "PresencePenalty": 0.6,
      "Stop": [
        "Human:",
        "AI:"
      ]
    },
    "QnA": {
      "Model": "text-davinci-002",
      "Temperature": 0.7,
      "MaxTokens": 100,
      "TopP": 0.8,
      "FrequencyPenalty": 0.3,
      "PresencePenalty": 0.4,
      "Stop": [
        "Q:",
        "A:"
      ]
    }
   }
  
```
# Consuming Library from the  Console App
 ```
namespace PlayGround
{
  internal class Program
    {
      private static async Task Main(string[] args)
        {
            //Load your appsettings.json 
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            
            // Create the configuration
            var configuration = builder.Build();

            var loggerFactory = new LoggerFactory();
            var logger = loggerFactory.CreateLogger<OpenAI>();
            var openai = new OpenAI(logger);
            var openaiCompletion = new OpenAICompletionHandler(openai, configuration);
           
           // Select the language mode that you want to use chat,qna etc
            string botType = "Chat";
            
            // Add question 
            var question = $" What are 5 key points I should know when studying Ancient Rome??";

            // Send the request
            var response = await openaiCompletion.Handle(new OpenAICompletionRequest { Prompt = question }, botType, CancellationToken.None);
            
            //Print the response.
            Console.WriteLine(response.FilterResponse());

            
        }
    }
    }
    
   ```
  
  ![alt text](https://github.com/csehammad/GPT3Wrapper/blob/main/sample.png?raw=true)

