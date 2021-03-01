using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Interfaces
{
    public interface _IDentalCheckWorkersRepository : IChecklDentalCheckWorkersModel
    {
        IEnumerable<_DentalCheckWorkers> GetDentalChecsAndkWorkers();

        _DentalCheckWorkers GetDentalCheckWorkers(int id);

        _DentalCheckWorkers EditDentalCheckWorkers(_DentalCheckWorkers dentalCheckWorkers, int id);

        _DentalCheckWorkers AddDentalCheckWorkers(_DentalCheckWorkers dentalCheckWorkers);

        _DentalCheckWorkers DeleteDentalCheckWorkers(int id);
    }
}
