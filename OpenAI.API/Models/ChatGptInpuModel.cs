namespace OpenAI.API.Models
{
    public class ChatGptInpuModel
    {
        public ChatGptInpuModel(string prompt)
        {
            this.prompt = prompt;

            temperature = 0.2m; // Margem de erro / criatividade
            max_tokens = 100; // Quantidade de Palavras 
            model = "text-davinci-003"; // Qual modelo da Open AI vamo usar
        }

        public string model{ get; set; }
        public string prompt { get; set; }
        public int max_tokens { get; set; }
        public decimal temperature { get; set; }
    }
}