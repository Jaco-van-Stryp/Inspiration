using MediatR;

namespace Insparation.Features.GenerateInsparation;

public record GenerateInsparationCommand(string? Topic) : IRequest<GenerateInsparationResponse>;