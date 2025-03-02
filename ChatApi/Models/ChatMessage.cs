namespace ChatApi.Models;

public class ChatMessage
{
    public string Text { get; set; } = string.Empty;
    public string Sender { get; set; } = string.Empty;
}

public class ChatRequest
{
    public string Message { get; set; } = string.Empty;
}

public class ChatResponse
{
    public string Text { get; set; } = string.Empty;
    public string Sender { get; set; } = "bot";
} 