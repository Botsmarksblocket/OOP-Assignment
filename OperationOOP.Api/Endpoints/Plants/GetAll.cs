﻿using OperationOOP.Core.Interfaces;


namespace OperationOOP.Api.Endpoints.Plants
{
    public class GetAll : IEndpoint
    {
        // Mapping
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/plants", Handle)
            .WithSummary("Get all plants.");

        // Response
        public record Response(
            int Id,
            string Name,
            string Species,
            PlantCareLevel CareLevel
            );

        //Retrieves all plants from the plant service and maps them to a response DTO.
        //Returns 200 OK result.
        private static IResult Handle(IPlantService plantService)
        {
            var plants = plantService.GetAll();

            return Results.Ok(plants.Select(plant => new Response(
                plant.Id,
                plant.Name,
                plant.Species,
                plant.CareLevel
                )));
        }
    }
}
