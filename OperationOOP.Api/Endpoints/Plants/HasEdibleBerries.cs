//using OperationOOP.Core.Interfaces;
//using System.Reflection.Metadata;

//namespace OperationOOP.Api.Endpoints.Plants
//{
//    public class HasEdibleBerries : IEndpoint
//    {
//        // Mapping
//        public static void MapEndpoint(IEndpointRouteBuilder app) => app
//            .MapGet("/edibleberries", Handle);

//        //Request and response
//        public record Response(
//            int Id,
//            string Name,
//            string Species,
//            PlantCareLevel CareLevel,
//            bool HasRipeBerry         
//            );

//        public static IResult Handle(IPlantService plantService)
//        {
//            var plants = plantService.GetAll();

//            var ediblePlants = plants

 
                                           

//        }
//    }
//}
