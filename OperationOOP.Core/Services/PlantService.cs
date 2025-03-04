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

        //Get all the plants from the database
        public List<Plant> GetAll() => _database.Plants;

        //Finds specific plant from database
        public Plant GetById(int id)
        {
            return _database.Plants.FirstOrDefault(p => p.Id == id);
        }
        //Insert a plant in the database and automatically gives it an ID
        public void Create(Plant plant)
        {
            plant.Id = _database.Plants.Any()
                       ? _database.Plants.Max(plant => plant.Id) + 1
                       : 1;

            _database.Plants.Add(plant);
        }

        //Deletes plant from database by ID
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
