using OperationOOP.Core.Models;
using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints.DeadlyNightshadeEndpoint;

public class Create : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/deadlynightshade", Handle)
        .WithSummary("Create a deadly nightshade plant");

    //Request and response
    public record Request(
        string Name,
        string Species,
        int AgeYears,
        PlantCareLevel CareLevel,
        bool HasRipeBerry
        );

    public record Response(
        int Id
        );


    //Creates a new Bonsai object and saves it using IPlantService.
    //Returns a 201 created response with the Bonsai's id
    public static IResult Handle([AsParameters] Request request, IPlantService plantService)
    {
        if (request == null) { return Results.NotFound(); }

        if (request.AgeYears < 0)
        {
            return Results.BadRequest("Age cannot be negative");
        }

        

        var deadlyNightshade = new DeadlyNightshade(request.Name, request.Species, request.AgeYears, request.CareLevel, request.HasRipeBerry)
        {
        };


        plantService.Create(deadlyNightshade);

        return Results.Created($"/deadlynightshade/{deadlyNightshade.Id}", new Response(deadlyNightshade.Id));
    }
}
