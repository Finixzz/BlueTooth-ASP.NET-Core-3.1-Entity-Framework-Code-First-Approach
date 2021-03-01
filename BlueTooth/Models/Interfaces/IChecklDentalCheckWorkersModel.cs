using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Interfaces
{
    public interface IChecklDentalCheckWorkersModel
    {
        bool ExistsInDb(int id);
        bool HasWorkerAssigned(int numberOfAssignedWorkers);
    }
}
