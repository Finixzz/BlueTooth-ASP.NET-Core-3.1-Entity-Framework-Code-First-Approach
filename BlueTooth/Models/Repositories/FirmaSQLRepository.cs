using BlueTooth.DbContext;
using BlueTooth.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Implementations
{
    public class FirmaSQLRepository : IFirmaRepository
    {

        private ApplicationDbContext _context;

        public FirmaSQLRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Firma CreateFirma(Firma firma)
        {
            _context.Firme.Add(firma);
            _context.SaveChanges();
            return firma;
        }

        public Firma DeleteFirma(int id)
        {
            Firma firmaInDb = _context.Firme.SingleOrDefault(c => c.Id == id);
            _context.Firme.Remove(firmaInDb);
            _context.SaveChanges();
            return firmaInDb;
        }

        public Firma EditFirma(Firma firma, int id)
        {
            Firma firmaInDb = _context.Firme.SingleOrDefault(c => c.Id == id);
            firmaInDb.Naziv = firma.Naziv;
            firmaInDb.Telefon = firma.Telefon;
            firmaInDb.Fax = firma.Fax;
            firmaInDb.Email = firma.Email;
            firmaInDb.Adresa = firma.Adresa;
            _context.SaveChanges();

            return firma;
        }

        public Firma GetFirma(int id)
        {
            return _context.Firme.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Firma> GetFirme()
        {
           return _context.Firme;
        }
    }
}
