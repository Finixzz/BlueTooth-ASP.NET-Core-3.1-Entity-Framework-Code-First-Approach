using BlueTooth.DbContext;
using BlueTooth.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Repositories
{
    public class EstablishedDiagnosisSQLRepository : IEstablishedDiagnosisRepository
    {
        private ApplicationDbContext _context;

        public EstablishedDiagnosisSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public EstablishedDiagnosis AddEDiagnose(EstablishedDiagnosis eDiagnose)
        {
            _context.EstablishedDiagnosis.Add(eDiagnose);
            _context.SaveChanges();
            return eDiagnose;
        }


        public EstablishedDiagnosis DeleteEDiagnose(int id)
        {
            EstablishedDiagnosis eDiagnoseInDb = _context.EstablishedDiagnosis.SingleOrDefault(c => c.Id == id);
            _context.EstablishedDiagnosis.Remove(eDiagnoseInDb);
            _context.SaveChanges();
            return eDiagnoseInDb;
        }

        public EstablishedDiagnosis EditEDiagnose(EstablishedDiagnosis eDiagnose, int id)
        {
            EstablishedDiagnosis eDiagnoseInDb = _context.EstablishedDiagnosis.SingleOrDefault(c => c.Id == id);
            eDiagnoseInDb.DentalCheckUpId = eDiagnose.DentalCheckUpId;
            eDiagnoseInDb.DiagnoseId = eDiagnose.DiagnoseId;
            _context.SaveChanges();
            return eDiagnose;
        }

        
        public EstablishedDiagnosis GetEDiagnose(int id)
        {
            return _context.EstablishedDiagnosis.SingleOrDefault(c => c.Id == id);

        }

        public IEnumerable<EstablishedDiagnosis> GetEDiagnosis()
        {
            return _context.EstablishedDiagnosis;

        }

    }
}
