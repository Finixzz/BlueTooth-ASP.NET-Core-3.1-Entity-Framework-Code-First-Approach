using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Interfaces
{

    //E stands for Established
    public interface IEstablishedDiagnosisRepository
    {
        EstablishedDiagnosis GetEDiagnose(int id);

        IEnumerable<EstablishedDiagnosis> GetEDiagnosis();

        EstablishedDiagnosis AddEDiagnose(EstablishedDiagnosis eDiagnose);

        EstablishedDiagnosis EditEDiagnose(EstablishedDiagnosis eDiagnose, int id);

        EstablishedDiagnosis DeleteEDiagnose(int id);
    }
}
