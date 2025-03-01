using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints.DeadlyNightshadeEndpoint;

public class GetAll : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/deadlynightshade", Handle)
        .WithSummary("Get all deadly nightshades");

    // Response
    public record Response(
        int Id,
        string Name,
        string Species,
        PlantCareLevel CareLevel,
        bool HasRipeBerry
        );

    //Retrieves all deadly nightshades from the plantservice and maps them to a response DTO.
    //Returns a list of responses as 200 OK result.
    private static IResult Handle(IPlantService plantService)
    {
        var plants = plantService.GetAll();

        return Results.Ok(plants.OfType<DeadlyNightshade>()
                           .Select(s => new Response(
                               s.Id,
                               s.Name,
                               s.Species,
                               s.CareLevel,
                               s.HasRipeBerry
                               )));

    }
}