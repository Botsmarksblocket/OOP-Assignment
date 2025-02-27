using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationOOP.Core.Data;
using OperationOOP.Core.Interfaces;
using OperationOOP.Core.Models;

namespace OperationOOP.Core.Services
{
    public class PlantService : IPlantService
    {

        private readonly IDatabase _database;

        //Using dependency injection 
        public PlantService(IDatabase database)
        {
            _database = database;
        }

        public List<Plant> GetAll() => _database.Plants;

        public Plant GetById(int id)
        {
            return _database.Plants.FirstOrDefault(p => p.Id == id);
        }
        public void Create(Plant plant)
        {
            plant.Id = _database.Plants.Any()
                       ? _database.Plants.Max(plant => plant.Id) + 1
                       : 1;

            _database.Plants.Add(plant);
        }

        public void Delete(int id)
        {
            var plant = GetById(id);
            if ( plant != null)
            {
                _database.Plants.Remove(plant);
            }

        }
    }
}
