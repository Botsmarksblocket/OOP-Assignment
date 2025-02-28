using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using OperationOOP.Core.Interfaces;

namespace OperationOOP.Core.Models
{
    //Superclass which the other plants inherit from
    public abstract class Plant : IEntity
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Species { get; private set; }
        public int AgeYears { get; private set; }
        public PlantCareLevel CareLevel { get; private set; }

        protected Plant(string name, string species, int ageYears, PlantCareLevel careLevel)
        {
            Name = name;
            Species = species;
            AgeYears = ageYears;
            CareLevel = careLevel;
        }
    }

    //Jsonconverter to show the carelevel as a string instead of an int
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PlantCareLevel
    {
        Beginner,
        Intermediate,
        Advanced,
        Master
    }
}
