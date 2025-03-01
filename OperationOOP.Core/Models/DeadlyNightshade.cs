using OperationOOP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models;

public class DeadlyNightshade : Plant, ICanHaveEdibleBerry
{
    public bool HasRipeBerry { get; set; }
    //DeadlyNightshade berries are poisonous so it's always set to true

    public bool HasPoisonousBerry => true;
    public DeadlyNightshade(string name, string species, int ageYears, PlantCareLevel careLevel, bool hasRipeBerry)
        : base(name, species, ageYears, careLevel)
    {
        HasRipeBerry = hasRipeBerry;
    }
}
