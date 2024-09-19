using Amazon.BedrockRuntime.Model;
using Amazon.BedrockRuntime;
using System.Text.Json;
using System.Text;
using SimpleAWSBedrockApp.Models;

public class AwsBedrockService
{
    private readonly IAmazonBedrockRuntime _bedrockRuntime;

    public AwsBedrockService(IAmazonBedrockRuntime bedrockRuntime)
    {
        _bedrockRuntime = bedrockRuntime;
    }

    public async Task<string> GenerateTextAsync(string prompt)
    {
        try
        {
            var payload = new CohereRequest(prompt);
            var jsonPayload = JsonSerializer.Serialize(payload);
            var body = new MemoryStream(Encoding.UTF8.GetBytes(jsonPayload));

            var request = new InvokeModelRequest
            {
                ModelId = "cohere.command-text-v14",
                Accept = "*/*",
                ContentType = "application/json",
                Body = body
            };

            var response = await _bedrockRuntime.InvokeModelAsync(request);
            var generatedText = JsonSerializer.Deserialize<CohereResponse>(response.Body);

            return generatedText.Generations[0].Text;
        }

        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    public async Task<string> SummarizeTextAsync(string prompt)
    {
        try
        {
            var payload = TitanTextRequest.CreateBodyJson(prompt);
            var jsonPayload = JsonSerializer.Serialize(payload);
            var body = new MemoryStream(Encoding.UTF8.GetBytes(jsonPayload));

            var request = new InvokeModelRequest
            {
                ModelId = "amazon.titan-text-premier-v1:0",
                Accept = "application/json",
                ContentType = "application/json",
                Body = body
            };

            var response = await _bedrockRuntime.InvokeModelAsync(request);

            using var responseStream = new StreamReader(response.Body);

            var responseBody = await responseStream.ReadToEndAsync();
            var jsonResponse = JsonDocument.Parse(responseBody);
            var summaryText = jsonResponse.RootElement
                .GetProperty("results")[0]
                .GetProperty("outputText")                
                .GetString();

            return summaryText;
        }

        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    public async Task<string> GenerateImageAsync(string prompt)
    {
        try
        {
            var jsonPayload = JsonSerializer.Serialize(new TitanImageRequest(prompt));
            var body = new MemoryStream(Encoding.UTF8.GetBytes(jsonPayload));

            var request = new InvokeModelRequest
            {
                ModelId = "amazon.titan-image-generator-v1",
                Accept = "application/json",
                ContentType = "application/json",
                Body = body
            };

            var response = await _bedrockRuntime.InvokeModelAsync(request);
            var imageData = await JsonDocument.ParseAsync(response.Body);
            var base64Image = imageData.RootElement.GetProperty("images")[0].ToString();

            return base64Image;
        }

        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }
}
