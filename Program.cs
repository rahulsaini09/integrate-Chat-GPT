using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenAI_API;

public class Program
{
    static async Task Main(string[] args)
    {
       
        Console.WriteLine("Ask me anything..");
        string query;
        query = Console.ReadLine();
        Console.WriteLine("give me few second, im working on your request..");

        var response = await GenerateContent(query);
        foreach(var item in response)
        {
            Console.WriteLine(item);
        }        
        Console.ReadLine();
    }

    static async Task<List<string>> GenerateContent(string query)
    {
        //https://platform.openai.com/account/api-keys

        var apiKey = "Your-secret-API-keys";
        var apiModel = "text-davinci-003";
        List<string> rq = new List<string>();
      
        OpenAIAPI api = new OpenAIAPI(new APIAuthentication(apiKey));
        var completionRequest = new OpenAI_API.Completions.CompletionRequest()
        {
            Prompt = query,
            Model = apiModel,
            Temperature = 0.5,
            MaxTokens = 100,
            TopP = 1.0,
            FrequencyPenalty = 0.0,
            PresencePenalty = 0.0,
        };

        try
        {
            var result = await api.Completions.CreateCompletionsAsync(completionRequest);
            foreach (var response in result.Completions)
            {             
                rq.Add(response.Text);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }        
        return rq;
    }
}

