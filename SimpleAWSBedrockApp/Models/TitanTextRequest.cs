using System.Text.Json.Nodes;

namespace SimpleAWSBedrockApp.Models
{
    public static class TitanTextRequest
    {
        public static JsonObject CreateBodyJson(string prompt)
        {
            var bodyJson = new JsonObject
            {
                ["inputText"] = prompt,
                ["textGenerationConfig"] = new JsonObject
                {
                    ["maxTokenCount"] = 512,
                    ["temperature"] = 0.7,
                    ["topP"] = 0.9,
                    ["stopSequences"] = Array.Empty<string>().AsArray()
                }
            };
            return bodyJson;
        }

        private static JsonArray AsArray(this IReadOnlyList<string> stringArray)
        {
            stringArray = stringArray ?? throw new ArgumentNullException(nameof(stringArray));

            var jsonArray = new JsonArray();

            foreach (var arr in stringArray)
            {
                jsonArray.Add(arr);
            }

            return jsonArray;
        }
    }
}
