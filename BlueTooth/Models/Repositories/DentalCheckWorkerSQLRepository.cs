using BlueTooth.DbContext;
using BlueTooth.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Repositories
{
    public class DentalCheckWorkerSQLRepository : IDentalCheckWorkerRepository
    {
        private ApplicationDbContext _context;


        public DentalCheckWorkerSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
 
        public DentalCheck_Worker AddDentalCheckWorker(DentalCheck_Worker dentalCheckWorker)
        {
            _context.DentalCheck_Workers.Add(dentalCheckWorker);
            _context.SaveChanges();
            return dentalCheckWorker;
        }

        public DentalCheck_Worker DeleteDentalCheckWorker(int id)
        {
            DentalCheck_Worker dentalCheckWorkerInDb = _context.DentalCheck_Workers.FirstOrDefault(c => c.DentalCheckUpId == id);
            _context.DentalCheck_Workers.Remove(dentalCheckWorkerInDb);
            _context.SaveChanges();
            return dentalCheckWorkerInDb;
        }

        public DentalCheck_Worker EditDentalCheckWorker(DentalCheck_Worker dentalCheckWorker, int id)
        {
            DentalCheck_Worker dentalCheckWorkerInDb = _context.DentalCheck_Workers.FirstOrDefault(c => c.DentalCheckUpId == id);
            dentalCheckWorkerInDb.DentalCheckUpId = dentalCheckWorker.DentalCheckUpId;
            dentalCheckWorkerInDb.WorkerId = dentalCheckWorker.WorkerId;
            _context.SaveChanges();
            return dentalCheckWorker;
        }

        public IEnumerable<DentalCheck_Worker> GetAll()
        {
            return _context.DentalCheck_Workers;
        }

        public DentalCheck_Worker GetDentalCheckWorker(int id)
        {
            return _context.DentalCheck_Workers.SingleOrDefault(c => c.DentalCheckUpId == id);
        }
    }
}
