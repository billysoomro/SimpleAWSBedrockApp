using System.Text.Json.Serialization;

namespace SimpleAWSBedrockApp.Models
{
    public class CohereResponse
    {
        [JsonPropertyName("generations")]
        public Generation[]? Generations { get; set; }
    }

    public class Generation
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }
    }
}
