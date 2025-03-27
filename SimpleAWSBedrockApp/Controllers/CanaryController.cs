using Microsoft.AspNetCore.Mvc;

namespace SimpleAWSBedrockApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CanaryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("The SimpleAWSBedrockApp is running.");
        }
    }
}
