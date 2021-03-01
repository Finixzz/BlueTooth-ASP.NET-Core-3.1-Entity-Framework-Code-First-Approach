using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Interfaces
{
    public interface IDentalCheckRepository
    {
        DentalCheckUp GetDentalCheckUp(int id);

        IEnumerable< DentalCheckUp>GetDentalChecks();

        DentalCheckUp EditDentalCheckUp(DentalCheckUp dentalCheckUp,int id);
        DentalCheckUp CreateDentalCheckUp(DentalCheckUp dentalCheckUp);

        DentalCheckUp DeleteDentalCheckUp(int id);
    }
}
