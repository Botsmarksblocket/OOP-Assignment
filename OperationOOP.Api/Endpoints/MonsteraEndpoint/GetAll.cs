using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints.MonsteraEndpoint;

public class GetAll : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/monstera", Handle)
        .WithSummary("Get all monsteras");

    // Response
    public record Response(
        int Id,
        string Name,
        string Species,
        PlantCareLevel CareLevel
        );

    //Retrieves all monsteras from the plantservice and maps them to a response DTO.
    //Returns 200 OK result.
    private static IResult Handle(IPlantService plantService)
    {
        var plants = plantService.GetAll();

        return Results.Ok(plants.OfType<Monstera>()
                           .Select(s => new Response(
                               s.Id,
                               s.Name,
                               s.Species,
                               s.CareLevel
                               )));

    }
}
