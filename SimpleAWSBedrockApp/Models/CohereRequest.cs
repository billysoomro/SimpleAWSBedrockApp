using System.Text.Json.Serialization;

namespace SimpleAWSBedrockApp.Models
{
    public class CohereRequest
    {
        public CohereRequest(string prompt)
        {
            Prompt = prompt;
        }

        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        [JsonPropertyName("max_tokens")]
        public int MaxTokens { get; set; } = 100;

        [JsonPropertyName("temperature")]
        public decimal Temperature { get; set; } = 0.7m;
    }
}
