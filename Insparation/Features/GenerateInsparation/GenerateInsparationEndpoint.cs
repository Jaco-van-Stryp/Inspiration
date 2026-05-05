using MediatR;

namespace Insparation.Features.GenerateInsparation;

public static class GenerateInsparationEndpoint
{
    public static void MapGenerateInsparationEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("GenerateInsparation", async (ISender sender, GenerateInsparationCommand command) =>
        {
            var results = await sender.Send(command);
            return TypedResults.Ok(results);
        }).WithName("GenerateInsparation");
    }
}