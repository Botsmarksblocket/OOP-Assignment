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
            PlantCareLevel CareLevel,
            BonsaiStyle Style
            );

        public record Response(
            int Id
            );


        //Creates a new Bonsai object and saves it using IPlantService.
        //Returns a 201 created response with the Bonsai's id
        public static IResult Handle(Request request, IPlantService plantService)
        {

            if(request.AgeYears < 0)
            {
                return Results.BadRequest("Age cannot be negative");
            }

            var bonsai = new Bonsai(request.Name, request.Species,request.AgeYears,request.CareLevel,request.Style)
            {

            };

            plantService.Create(bonsai);

            return Results.Created($"/bonsai/{bonsai.Id}", new Response(bonsai.Id));
        }
    }
}
