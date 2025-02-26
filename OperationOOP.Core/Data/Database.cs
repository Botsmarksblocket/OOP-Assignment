using OperationOOP.Core.Models;

namespace OperationOOP.Core.Data
{
    public interface IDatabase
    {
        List<Plant> Plants { get; set; }
    }

    public class Database : IDatabase
    {
        public List<Plant> Plants { get; set; } = new List<Plant>();
    }
}
