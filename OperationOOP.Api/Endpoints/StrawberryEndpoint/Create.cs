using Microsoft.AspNetCore.Mvc;
using OperationOOP.Core.Interfaces;
using System.Reflection.Metadata;
using OperationOOP.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

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


    //Creates a new Bonsai object and saves it using IPlantService.
    //Returns a 201 created response with the Bonsai's id
    public static IResult Handle([AsParameters] Request request, IPlantService plantService)
    {
        if (request == null) { return Results.NotFound(); }

        if (request.AgeYears < 0)
        {
            return Results.BadRequest("Age cannot be negative");
        }

        var strawberry = new Strawberry(request.Name, request.Species, request.AgeYears, request.CareLevel)
        {
            HasRipeBerry = request.HasRipeBerry,
        };


        plantService.Create(strawberry);

        return Results.Created($"/strawberry/{strawberry.Id}", new Response(strawberry.Id));
    }
}
