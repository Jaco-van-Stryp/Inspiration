using System.Text.Json;
using Inspiration.Services.AIService;
using MediatR;

namespace Inspiration.Features.GenerateInspiration;

public class GenerateInspirationHandler(IAiService aiService) : IRequestHandler<GenerateInspirationCommand, List<GenerateInspirationResponse>>
{
    public async Task<List<GenerateInspirationResponse>> Handle(GenerateInspirationCommand request, CancellationToken cancellationToken)
    {
        var userPrompt = "Topic: " + request.Topic;
        var generatedText = await aiService.GenerateTextAsync(systemPrompt: _systemPrompt, userPrompt: userPrompt, cancellationToken);
        var json = generatedText.Trim();
        if (json.StartsWith("```"))
        {
            var start = json.IndexOf('\n') + 1;
            var end = json.LastIndexOf("```", StringComparison.Ordinal);
            json = json[start..end].Trim();
        }
        return JsonSerializer.Deserialize<List<GenerateInspirationResponse>>(json) ?? [];
    }

    private readonly string _systemPrompt =
        "You are an inspiration generator for software engineers. Come up with 10 unique, fun, and creative hobby software project ideas. " +
        "These can already exist or be completely new. Be as creative as possible. The user will be working with C# and Angular. " +
        "Respond ONLY with a raw JSON array — no markdown, no code fences, no explanation, no extra text before or after. " +
        "Use this exact format: " +
        "[{\"Idea\": \"The Idea topic\", \"Description\": \"The Idea Description\"}, ...]";
}