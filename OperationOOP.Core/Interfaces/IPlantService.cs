using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationOOP.Core.Models;

namespace OperationOOP.Core.Interfaces
{
    public interface IPlantService
    {
        List<Plant> GetAll();
        Plant GetById(int id);
        void Add (Plant plant);
    }
}
