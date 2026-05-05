namespace Inspiration.Services.AIService;

public interface IAiService
{
    Task<string> GenerateTextAsync(string systemPrompt, string userPrompt, CancellationToken ct = default);
}