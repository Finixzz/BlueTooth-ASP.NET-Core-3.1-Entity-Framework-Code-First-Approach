using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Interfaces
{
    public interface IDiagnoseRepository
    {
        Diagnose GetDiagnose(int id);

        IEnumerable<Diagnose> GetDiagnoses();

        Diagnose AddDiagnose(Diagnose diagnose);

        Diagnose EditDiagnose(Diagnose diagnose, int id);

        Diagnose DeleteDiagnose(int id);
    }
}
