using BlueTooth.DbContext;
using BlueTooth.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Repositories
{
    public class DentalCheckUpSQLRepository : IDentalCheckRepository
    {
        private ApplicationDbContext _context;

        public DentalCheckUpSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public DentalCheckUp CreateDentalCheckUp(DentalCheckUp dentalCheckUp)
        {
            _context.DentalChecks.Add(dentalCheckUp);
            _context.SaveChanges();
            return dentalCheckUp;
        }

        public DentalCheckUp DeleteDentalCheckUp(int id)
        {
            DentalCheckUp dentalCheckUpInDb = _context.DentalChecks.SingleOrDefault(c => c.Id == id);
            _context.DentalChecks.Remove(dentalCheckUpInDb);
            _context.SaveChanges();
            return dentalCheckUpInDb;
        }

        public DentalCheckUp EditDentalCheckUp(DentalCheckUp dentalCheckUp, int id)
        {
            DentalCheckUp dentalCheckUpInDb = _context.DentalChecks.SingleOrDefault(c => c.Id == id);
            dentalCheckUpInDb.AppointmentId = dentalCheckUp.AppointmentId;
            dentalCheckUpInDb.Description = dentalCheckUp.Description;
            _context.SaveChanges();
            return dentalCheckUp;
        }

        public IEnumerable<DentalCheckUp> GetDentalChecks()
        {
            return _context.DentalChecks;
        }

        public DentalCheckUp GetDentalCheckUp(int id)
        {
            return _context.DentalChecks.SingleOrDefault(c => c.Id == id);
        }
    }
}
