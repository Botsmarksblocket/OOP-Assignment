﻿using OperationOOP.Core.Interfaces;
using System.Reflection.Metadata;

namespace OperationOOP.Api.Endpoints.Plants
{
    public class HasEdibleBerries : IEndpoint
    {
        // Mapping
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/edibleberries", Handle);

        //Request and response
        public record Response(
            int Id,
            string Name,
            string Species,
            PlantCareLevel CareLevel,
            bool HasRipeBerry,
            bool HasPoisonousBerry
            );

        public static IResult Handle(IPlantService plantService)
        {

            //Filters all Plants with berries, checks if they are OK to eat, and maps them to a Response DTO
            var plantsWithEdibleBerries = plantService.GetAll()
                 .OfType<ICanHaveEdibleBerry>()
                 .Where(p => p.HasRipeBerry && !p.HasPoisonousBerry)
                 .Select(p =>
                 {
                     var plant = (Plant)p;
                     return new Response(plant.Id, plant.Name, plant.Species, plant.CareLevel, p.HasRipeBerry, p.HasPoisonousBerry);
                 });

            return Results.Ok(plantsWithEdibleBerries);
        }
    }
}
