using Microsoft.AspNetCore.Mvc;
using OpenAI.API.Models;
using System.Text;
using System.Text.Json;

namespace OpenAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAiIntegrationController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public OpenAiIntegrationController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string text, [FromServices] IConfiguration configuration)
        {
            var token = ""; // Api Key da Open AI

            _httpClient.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var model = new ChatGptInpuModel(text);

            var requestBody = JsonSerializer.Serialize(model);

            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/completions", content);

            var result = await response.Content.ReadFromJsonAsync<ChatGptViewModel>();

            var promptResponse = result?.choices.FirstOrDefault();

            if (promptResponse == null)
                throw new Exception();

            return Ok(promptResponse.text.Replace("\n", "").Replace("\t", ""));
        }
    }
}