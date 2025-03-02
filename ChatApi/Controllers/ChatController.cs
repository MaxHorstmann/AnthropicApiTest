using Microsoft.AspNetCore.Mvc;
using ChatApi.Models;

namespace ChatApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly ILogger<ChatController> _logger;

    public ChatController(ILogger<ChatController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<ChatResponse>> PostMessage([FromBody] ChatRequest request)
    {
        try
        {
            // Simulate processing delay
            await Task.Delay(1000);

            // Here you can integrate with an AI service or implement your own logic
            var response = new ChatResponse
            {
                Text = $"You said: {request.Message}",
                Sender = "bot"
            };

            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing chat message");
            return StatusCode(500, new { error = "Internal server error" });
        }
    }
} 