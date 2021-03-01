using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Interfaces
{
    public interface _IDentalCheckServicesRepository
    {
        _DentalCheckServices AddDentalCheckServices(_DentalCheckServices dcs);

        _DentalCheckServices GetDentalCheckServices(int id);

        IEnumerable<_DentalCheckServices> GetAllDentalCheckServices();
    }
}
