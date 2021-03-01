using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Interfaces
{
    public interface IFirmaRepository
    {
        Firma GetFirma(int id);

        IEnumerable<Firma> GetFirme();

        Firma CreateFirma(Firma firma);

        Firma EditFirma(Firma firma, int id);

        Firma DeleteFirma(int id);
    }
}
