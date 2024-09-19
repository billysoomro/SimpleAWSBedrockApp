using System.Text.Json.Serialization;

namespace SimpleAWSBedrockApp.Models
{
    public class TitanImageRequest
    {
        public TitanImageRequest(string text)
        {
            TextToImageParams = new TextToImageParams(text);
            TaskType = "TEXT_IMAGE";
            ImageGenerationConfig = new ImageGenerationConfig(8, 0, "standard", 512, 512, 1);
        }

        [JsonPropertyName("textToImageParams")]
        public TextToImageParams TextToImageParams { get; set; }

        [JsonPropertyName("taskType")]
        public string TaskType { get; set; } = "TEXT_IMAGE";

        [JsonPropertyName("imageGenerationConfig")]
        public ImageGenerationConfig ImageGenerationConfig { get; set; } = new ImageGenerationConfig(8, 0, "standard", 512, 512, 1);
    }

    public class TextToImageParams
    {
        public TextToImageParams(string text)
        {
            Text = text;
        }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class ImageGenerationConfig
    {
        public ImageGenerationConfig(int cfgScale, int seed, string quality, int width, int height, int numberOfImages)
        {
            CfgScale = cfgScale;
            Seed = seed;
            Quality = quality;
            Width = width;
            Height = height;
            NumberOfImages = numberOfImages;
        }

        [JsonPropertyName("cfgScale")]
        public int CfgScale { get; set; } = 8;

        [JsonPropertyName("seed")]
        public int Seed { get; set; } = 0;

        [JsonPropertyName("quality")]
        public string Quality { get; set; } = "standard";

        [JsonPropertyName("width")]
        public int Width { get; set; } = 512;

        [JsonPropertyName("height")]
        public int Height { get; set; } = 512;

        [JsonPropertyName("numberOfImages")]
        public int NumberOfImages { get; set; } = 1;
    }
}
