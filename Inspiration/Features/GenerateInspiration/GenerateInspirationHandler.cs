using System.Text.Json;
using Inspiration.Services.AIService;
using MediatR;

namespace Inspiration.Features.GenerateInspiration;

public class GenerateInspirationHandler(IAiService aiService) : IRequestHandler<GenerateInspirationCommand, GenerateInspirationResponse>
{
    public async Task<GenerateInspirationResponse> Handle(GenerateInspirationCommand request, CancellationToken cancellationToken)
    {
        var userPrompt = "Topic: " + request.Topic;
        var generatedText = await aiService.GenerateTextAsync(systemPrompt: _systemPrompt, userPrompt: userPrompt, cancellationToken);
        var deserialized = JsonSerializer.Deserialize<GenerateInspirationResponse>(generatedText);
        return deserialized;
    }

    private readonly string _systemPrompt =
        "You are a Inspiration to software engineers, you must come up with 10 unique random fun and creative ideas for hobby software projects." +
        "These can already exist, or they may be completely new. Be as creative as possible. The user will be working with C# and Angular. You must only respond in JSON Format, no pre-text or anything like that. " +
        "Format to respond in:" +
        "[{" +
        "Idea: \"The Idea topic\"" +
        "Description: \"The Idea Description\"" +
        "}, x10 ]";
}