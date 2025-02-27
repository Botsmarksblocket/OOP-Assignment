using Microsoft.AspNetCore.Mvc;
using OperationOOP.Core.Interfaces;
using System.Reflection.Metadata;
using static OperationOOP.Core.Models.Plant;
using static OperationOOP.Core.Models.Bonsai;


namespace OperationOOP.Api.Endpoints.Plants
{
    public class CreateBonsai
    {
        // Mapping
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapPost("/bonsai", Handle);

        //Request and response
        public record Request(
            string Name,
            string Species,
            int AgeYears,
            DateTime LastWatered,
            DateTime LastPruned,
            PlantCareLevel CareLevel,
            BonsaiStyle Style
            );

        public record Response(
            int Id
            );

        public static IResult Handle(Request request, IPlantService plantService)
        {

            var bonsai = new Bonsai()
            {
                Name = request.Name,
                Species = request.Species,
                AgeYears = request.AgeYears,
                LastWatered = request.LastWatered,
                LastPruned = request.LastPruned,
                CareLevel = request.CareLevel,
                Style = request.Style
            };

            plantService.Create(bonsai);

            return Results.Created($"/bonsai/{bonsai.Id}", new Response(bonsai.Id));
        }
    }
}
