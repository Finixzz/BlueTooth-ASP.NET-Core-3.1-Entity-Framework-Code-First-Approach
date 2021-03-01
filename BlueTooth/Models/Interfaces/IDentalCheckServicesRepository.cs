using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Interfaces
{
    public interface IDentalCheckServicesRepository
    {
        DentalCheck_Service GetDentalCheck(int id);

        IEnumerable<DentalCheck_Service> GetDentalCheckServices();

        DentalCheck_Service AddDentalCheckService(DentalCheck_Service dentalCheckService);

        DentalCheck_Service EditDentalCheckService(DentalCheck_Service dentalCheckService,int id);

        DentalCheck_Service DeleteDentalCheckService(int id);
    }
}
