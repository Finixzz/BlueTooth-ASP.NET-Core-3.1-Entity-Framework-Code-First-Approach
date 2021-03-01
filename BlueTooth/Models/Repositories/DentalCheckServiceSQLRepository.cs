using BlueTooth.DbContext;
using BlueTooth.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Repositories
{
    public class DentalCheckServiceSQLRepository : IDentalCheckServicesRepository
    {
        private ApplicationDbContext _context;

        public DentalCheckServiceSQLRepository(ApplicationDbContext context)
        {
            _context=context;
        }

        public DentalCheck_Service AddDentalCheckService(DentalCheck_Service dentalCheckService)
        {
            _context.DentalCheckServices.Add(dentalCheckService);
            _context.SaveChanges();
            return dentalCheckService;
        }

        public DentalCheck_Service DeleteDentalCheckService(int id)
        {
            DentalCheck_Service dcsInDb = _context.DentalCheckServices.SingleOrDefault(c => c.DentalCheckID == id);
            _context.DentalCheckServices.Remove(dcsInDb);
            _context.SaveChanges();
            return dcsInDb;
        }

        public DentalCheck_Service EditDentalCheckService(DentalCheck_Service dentalCheckService, int id)
        {
            DentalCheck_Service dcsInDb = _context.DentalCheckServices.FirstOrDefault(c => c.DentalCheckID == id);
            dcsInDb.ServiceID = dentalCheckService.ServiceID;
            _context.SaveChanges();
            return dentalCheckService;
        }

        public DentalCheck_Service GetDentalCheck(int id)
        {
            return _context.DentalCheckServices.SingleOrDefault(c => c.DentalCheckID == id);

        }

        public IEnumerable<DentalCheck_Service> GetDentalCheckServices()
        {
            return _context.DentalCheckServices;
        }
    }
}
