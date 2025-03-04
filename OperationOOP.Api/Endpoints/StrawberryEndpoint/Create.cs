using OperationOOP.Core.Interfaces;


namespace OperationOOP.Api.Endpoints.StrawberryEndpoint;    

public class Create : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapPost("/strawberry", Handle)
        .WithSummary("Create Strawberry plant");

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


    //Creates a strawberry plant and saves it to the database using IPlantService.
    //Returns a 201 created response with the strawberrys id
    public static IResult Handle(Request request, IPlantService plantService)
    {
        if (request.AgeYears < 0)
        {
            return Results.BadRequest("Age cannot be negative");
        }

        var strawberry = new Strawberry(request.Name, request.Species, request.AgeYears, request.CareLevel, request.HasRipeBerry);


        plantService.Create(strawberry);

        return Results.Created($"/strawberry/{strawberry.Id}", new Response(strawberry.Id));
    }
}
