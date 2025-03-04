﻿using OperationOOP.Core.Interfaces;

namespace OperationOOP.Api.Endpoints.StrawberryEndpoint;

public class GetAll : IEndpoint
{
    // Mapping
    public static void MapEndpoint(IEndpointRouteBuilder app) => app
        .MapGet("/strawberries", Handle);

    // Response
    public record Response(
        int Id,
        string Name,
        string Species,
        PlantCareLevel CareLevel,
        bool HasRipeBerry
        );

    //Retrieves all strawberries from the plant service and maps them to a response DTO.
    //Returns a list of responses as 200 OK result.
    private static IResult Handle(IPlantService plantService)
    {
        var plants = plantService.GetAll();

        return Results.Ok(plants.OfType<Strawberry>()
                           .Select(s => new Response(
                               s.Id,
                               s.Name,
                               s.Species,
                               s.CareLevel,
                               s.HasRipeBerry
                               )));

    }
}