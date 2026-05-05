using MediatR;

namespace Inspiration.Features.GenerateInspiration;

public static class GenerateInspirationEndpoint
{
    public static void MapGenerateInspirationEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("GenerateInspiration", async (ISender sender, GenerateInspirationCommand command) =>
        {
            var results = await sender.Send(command);
            return TypedResults.Ok(results);
        }).WithName("GenerateInspiration");
    }
}