using OperationOOP.Core.Interfaces;
using static OperationOOP.Core.Models.Plant;

namespace OperationOOP.Api.Endpoints.Plants
{
    public class GetAllPlants : IEndpoint
    {
        // Mapping
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/plants", Handle);



        // Response
        public record Response(
            int Id,
            string Species,
            DateTime LastWatered,
            DateTime LastPruned,
            PlantCareLevel CareLevel
            );



        // Logic

        private static List<Response> Handle(IPlantService plantService)
        {
            var plants = plantService.GetAll();
            
            plants.Select ( item  => new Response(
                Id : item.Id,
                Species: item.Species,
                LastWatered: item.LastWatered,
                LastPruned: item.LastPruned,
                CareLevel: item.CareLevel                
                )).ToList();
        



        }
    }
}
