using OperationOOP.Core.Interfaces;

namespace OperationOOP.Core.Models;

public class Strawberry : Plant, IHasRipeBerry
{
    public bool HasRipeBerry { get; set; } = false;
    
    public Strawberry(string name, string species, int ageYears, PlantCareLevel careLevel)
         : base(name, species, ageYears, careLevel)
    {

    }
}