using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationOOP.Core.Interfaces;

namespace OperationOOP.Core.Models
{
    public abstract class Plant : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int AgeYears { get; set; }
        public DateTime LastWatered { get; set; }
        public DateTime LastPruned { get; set; }
        public PlantCareLevel CareLevel { get; set; }

        public enum PlantCareLevel
        {
            Beginner,
            Intermediate,
            Advanced,
            Master
        }
    }

}
