using BlueTooth.DbContext;
using BlueTooth.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Repositories
{
    public class _DentalCheckServicesSQLRepository : _IDentalCheckServicesRepository
    {
        private IDentalCheckServicesRepository dentalCheckServicesRepository;
        private IDentalCheckRepository dentalCheckRepository;

        public _DentalCheckServicesSQLRepository(IDentalCheckServicesRepository dentalCheckServicesRepository,
                                                IDentalCheckRepository dentalCheckRepository)
        {
            this.dentalCheckServicesRepository = dentalCheckServicesRepository;
            this.dentalCheckRepository = dentalCheckRepository;
        }
        public _DentalCheckServices AddDentalCheckServices(_DentalCheckServices dcs)
        {
            int dentalCheckID = dcs.DentalCheckID;
            for(int i = 0; i < dcs.Services.Count(); i++)
            {
                DentalCheck_Service dc_s = new DentalCheck_Service()
                {
                    DentalCheckID = dentalCheckID,
                    ServiceID = dcs.Services[i]
                };
                dentalCheckServicesRepository.AddDentalCheckService(dc_s);
            }
            return dcs;
        }

        public IEnumerable<_DentalCheckServices> GetAllDentalCheckServices()
        {
            
            var dentalChecks = dentalCheckRepository.GetDentalChecks().ToList();
            var dServices= dentalCheckServicesRepository.GetDentalCheckServices().ToList();
            List<_DentalCheckServices> dcsList = new List<_DentalCheckServices>();
            for(int i = 0; i < dentalChecks.Count(); i++)
            {
                _DentalCheckServices dcs = new _DentalCheckServices()
                {
                    DentalCheckID = dentalChecks[i].Id
                };
                for (int j = 0; j < dServices.Count(); j++)
                {
                    if (dServices[j].DentalCheckID == dcs.DentalCheckID)
                    {
                        dcs.Services.Add(dServices[j].ServiceID);
                    }
                }
                dcsList.Add(dcs);
            }
            return dcsList;
        }

        public _DentalCheckServices GetDentalCheckServices(int id)
        {
            var dentalCheckServices = dentalCheckServicesRepository.GetDentalCheckServices().ToList();
            _DentalCheckServices dcs = new _DentalCheckServices()
            {
                DentalCheckID = id
            };
            for(int i = 0; i < dentalCheckServices.Count(); i++)
            {
                if (dentalCheckServices[i].DentalCheckID == dcs.DentalCheckID)
                    dcs.Services.Add(dentalCheckServices[i].ServiceID);
            }
            return dcs;
        }
    }
}
