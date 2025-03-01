using OperationOOP.Core.Interfaces;
using OperationOOP.Core.Models;

namespace OperationOOP.Api.Endpoints.MonsteraEndpoint;

public class Create : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/monstera", Handle)
        .WithSummary("Create a monstera plant");

    //Request and response
    public record Request(
        string Name,
        string Species,
        int AgeYears,
        PlantCareLevel CareLevel
        );

    public record Response(
        int Id
        );

    //Creates a monstera and saves it to the database using IPlantService.
    //Returns a 201 created response with the monstera nightshades id
    public static IResult Handle(Request request, IPlantService plantService)
    {
        if (request == null) { return Results.NotFound(); }

        if (request.AgeYears < 0)
        {
            return Results.BadRequest("Age cannot be negative");
        }

        var monstera = new Monstera(request.Name, request.Species, request.AgeYears, request.CareLevel);


        plantService.Create(monstera);

        return Results.Created($"/monstera/{monstera.Id}", new Response(monstera.Id));
    }
}
