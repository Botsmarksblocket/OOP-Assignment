using OperationOOP.Core.Interfaces;


namespace OperationOOP.Api.Endpoints.Plants
{
    public class GetAll : IEndpoint
    {
        // Mapping
        public static void MapEndpoint(IEndpointRouteBuilder app) => app
            .MapGet("/plants", Handle);

        // Response
        public record Response(
            int Id,
            string Name,
            string Species,
            PlantCareLevel CareLevel
            );

        //Retrieves all plants from the plant service and maps them to a response DTO.
        //Returns a list of responses as 200 OK result.
        private static IResult Handle(IPlantService plantService)
        {
            var plants = plantService.GetAll();

            var response = plants.Select
                (item => new Response(
                Id: item.Id,
                Name: item.Name,
                Species: item.Species,
                //Shows the string value of the CareLevel, not the enumvalue
                CareLevel: item.CareLevel
                ))
                .ToList();

            return Results.Ok(response);
        }
    }
}
