using Microsoft.AspNetCore.Mvc;

namespace SimpleAWSBedrockApp.Controllers
{
    public class BedrockController : Controller
    {
        private readonly AwsBedrockService _bedrockService;

        public BedrockController(AwsBedrockService bedrockService)
        {
            _bedrockService = bedrockService;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateText(string prompt)
        {
            var result = await _bedrockService.GenerateTextAsync(prompt);

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> SummarizeText(string prompt)
        {
            var result = await _bedrockService.SummarizeTextAsync(prompt);

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateImage(string prompt)
        {
            var result = await _bedrockService.GenerateImageAsync(prompt);

            return Json(result);
        }
    }
}
