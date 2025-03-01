using OperationOOP.Core.Interfaces;
using OperationOOP.Core.Services;
using System.Reflection.Metadata;

namespace OperationOOP.Api.Endpoints.Plants
{
    public class Delete : IEndpoint
    {
        // Mapping
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapDelete("/plants/{id:int}", Handle);

        //Deletes a plant with a specific ID
        //If the ID doesn't exist, returns 404 not found
        //If the ID exists, plant gets removed and returns 204
        private static IResult Handle(int id, IPlantService plantService)
        {            
            var plant = plantService.GetById(id);

            if (plant == null)
            {
                return Results.NotFound();
            }

            plantService.Delete(id);

            return Results.NoContent();
        }
    }
}
