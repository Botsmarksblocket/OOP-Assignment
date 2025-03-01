using OperationOOP.Core.Interfaces;

namespace OperationOOP.Core.Models;

public class Strawberry : Plant, ICanHaveEdibleBerry
{
    public bool HasRipeBerry { get; set; }

    //Strawberries are never poisonous so it's always set to false
    public bool HasPoisonousBerry => false;
    
    public Strawberry(string name, string species, int ageYears, PlantCareLevel careLevel, bool hasRipeBerry)
         : base(name, species, ageYears, careLevel)
    {
        HasRipeBerry = hasRipeBerry;
    }
}