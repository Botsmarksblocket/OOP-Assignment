using OperationOOP.Core.Interfaces;
using OperationOOP.Core.Services;
using System.Reflection.Metadata;

namespace OperationOOP.Api.Endpoints.Plants
{
    public class Delete
    {
        // Mapping
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapDelete("/plants/{id:int}", Handle);

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
