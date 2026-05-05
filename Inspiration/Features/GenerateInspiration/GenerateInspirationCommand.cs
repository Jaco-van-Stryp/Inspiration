using MediatR;

namespace Inspiration.Features.GenerateInspiration;

public record GenerateInspirationCommand(string? Topic) : IRequest<List<GenerateInspirationResponse>>;