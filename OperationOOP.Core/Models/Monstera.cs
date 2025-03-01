using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Models
{
    public class Monstera : Plant
    {
        public Monstera(string name, string species, int ageYears, PlantCareLevel careLevel)
             : base(name, species, ageYears, careLevel)
        {

        }
    }
}
