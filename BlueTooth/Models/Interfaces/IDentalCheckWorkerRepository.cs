using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Interfaces
{
    public interface IDentalCheckWorkerRepository
    {
        DentalCheck_Worker GetDentalCheckWorker(int id);

        IEnumerable<DentalCheck_Worker> GetAll();

        DentalCheck_Worker AddDentalCheckWorker(DentalCheck_Worker dentalCheckWorker);

        DentalCheck_Worker EditDentalCheckWorker(DentalCheck_Worker dentalCheckWorker, int id);

        DentalCheck_Worker DeleteDentalCheckWorker(int id);
    }
}
