using BlueTooth.DbContext;
using BlueTooth.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Repositories
{
    public class DiagnoseSQLRepository : IDiagnoseRepository
    {
        private ApplicationDbContext _context;

        public DiagnoseSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Diagnose AddDiagnose(Diagnose diagnose)
        {
            _context.Diagnoses.Add(diagnose);
            _context.SaveChanges();
            return diagnose;
        }

        public Diagnose DeleteDiagnose(int id)
        {
            Diagnose diagnoseInDb = _context.Diagnoses.SingleOrDefault(c => c.Id == id);
            _context.Diagnoses.Remove(diagnoseInDb);
            _context.SaveChanges();
            return diagnoseInDb;
        }

        public Diagnose EditDiagnose(Diagnose diagnose, int id)
        {
            Diagnose diagnoseInDb = _context.Diagnoses.SingleOrDefault(c => c.Id == id);
            diagnoseInDb.Name = diagnose.Name;
            _context.SaveChanges();
            return diagnose;
        }

        public Diagnose GetDiagnose(int id)
        {
            return _context.Diagnoses.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Diagnose> GetDiagnoses()
        {
            return _context.Diagnoses;
        }
    }
}
