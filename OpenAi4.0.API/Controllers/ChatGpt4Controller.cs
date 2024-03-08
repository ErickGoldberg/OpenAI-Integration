using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

namespace OpenAi4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGpt4Controller : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> GetAIResponse(string searchText)
        {
            const string APIKEY = "";
            string answer = string.Empty;

            var openAi = new OpenAIAPI(APIKEY);
            CompletionRequest completion = new CompletionRequest();

            completion.Prompt = searchText;
            completion.Model = OpenAI_API.Models.Model.DefaultModel;
            completion.MaxTokens = 500;
            completion.Temperature = 0;

            var result = await openAi.Completions.CreateCompletionAsync(completion);
            foreach (var item in result.Completions)
            {
                answer += item.Text;
            }

            return Ok(answer);
        }
    }
}
