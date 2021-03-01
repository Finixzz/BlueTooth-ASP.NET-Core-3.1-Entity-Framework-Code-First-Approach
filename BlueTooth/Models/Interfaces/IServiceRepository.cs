using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Interfaces
{
    public interface IServiceRepository
    {
        Service GetService(int id);

        IEnumerable<Service> GetServices();

        Service AddService(Service service);

        Service EditService(Service service, int id);

        Service DeleteService(int id);
    }
}
