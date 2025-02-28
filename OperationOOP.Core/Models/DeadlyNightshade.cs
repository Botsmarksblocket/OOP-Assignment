using OperationOOP.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public class DeadlyNightshade : Plant, IHasPoisonousBerry
    {
        public bool HasRipeBerry { get; set; } = false;
        public bool HasPoisonousBerry { get; set; } = false;

        public DeadlyNightshade(string name, string species, int ageYears, PlantCareLevel careLevel)
            : base(name, species, ageYears, careLevel)
        {

        }
    }
}
