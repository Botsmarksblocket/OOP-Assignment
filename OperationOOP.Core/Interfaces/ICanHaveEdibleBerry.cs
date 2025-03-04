using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationOOP.Core.Interfaces
{
    public interface ICanHaveEdibleBerry
    {
        bool HasRipeBerry { get; set; }
        bool HasPoisonousBerry { get; }
    }
}
