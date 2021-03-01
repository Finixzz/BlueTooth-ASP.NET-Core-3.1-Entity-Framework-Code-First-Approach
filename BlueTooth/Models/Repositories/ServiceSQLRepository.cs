using BlueTooth.DbContext;
using BlueTooth.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Repositories
{
    public class ServiceSQLRepository : IServiceRepository
    {
        private ApplicationDbContext _context;

        public ServiceSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Service AddService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return service;
        }

        public Service DeleteService(int id)
        {
            Service serviceInDb = _context.Services.SingleOrDefault(c => c.Id == id);
            _context.Services.Remove(serviceInDb);
            _context.SaveChanges();
            return serviceInDb;
        }

        public Service EditService(Service service, int id)
        {
            Service serviceInDb = _context.Services.SingleOrDefault(c => c.Id == id);
            serviceInDb.Name = service.Name;
            serviceInDb.Price = service.Price;
            _context.SaveChanges();
            return service;
        }

        public Service GetService(int id)
        {
            return _context.Services.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Service> GetServices()
        {
            return _context.Services;
        }
    }
}
