using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Interfaces
{
    public interface IHasRipeBerry
    {
        bool HasRipeBerry { get; set; }
    }

    public interface IHasPoisonousBerry : IHasRipeBerry
    {
        bool HasPoisonousBerry { get; }
    }
}
