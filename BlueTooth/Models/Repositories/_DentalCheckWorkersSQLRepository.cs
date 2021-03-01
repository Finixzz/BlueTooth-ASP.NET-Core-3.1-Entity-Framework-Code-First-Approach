using BlueTooth.DbContext;
using BlueTooth.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models.Repositories
{
    public class _DentalCheckWorkersSQLRepository : _IDentalCheckWorkersRepository
    {
        private IDentalCheckWorkerRepository _dentalCheckWorkerRepository;
        private IDentalCheckRepository _dentalCheckRepository;
        
        public _DentalCheckWorkersSQLRepository(IDentalCheckWorkerRepository dentalCheckWorkerRepository,
                                                IDentalCheckRepository dentalCheckRepository)
        {
            _dentalCheckWorkerRepository = dentalCheckWorkerRepository;
            _dentalCheckRepository = dentalCheckRepository;
        }

        public bool ExistsInDb(int id)
        {
            if (_dentalCheckRepository.GetDentalCheckUp(id) == null)
                return false;
            return true;
        }
        public bool HasWorkerAssigned(int numberOfAssignedWorkers)
        {
            if (numberOfAssignedWorkers == 0)
                return false;
            return true;
        }
        public _DentalCheckWorkers AddDentalCheckWorkers(_DentalCheckWorkers dentalCheckWorkers)
        {
            int numOfParticipatedWorkers = dentalCheckWorkers.IdList.Count();
            for(int i = 0; i < numOfParticipatedWorkers;i++)
            {
                DentalCheck_Worker dentalCheck_Worker = new DentalCheck_Worker()
                {
                    DentalCheckUpId = dentalCheckWorkers.DentalCheckUpId,
                    WorkerId = dentalCheckWorkers.IdList[i]
                };
                _dentalCheckWorkerRepository.AddDentalCheckWorker(dentalCheck_Worker);
            }
            return dentalCheckWorkers;
        }

        public _DentalCheckWorkers DeleteDentalCheckWorkers(int id)
        {
            _DentalCheckWorkers dentalCheckWorkersInDb = new _DentalCheckWorkers()
            {
                DentalCheckUpId = id
            };
            var participaredWorkers = _dentalCheckWorkerRepository.GetAll().ToList();
            for(int i = 0; i < participaredWorkers.Count(); i++)
            {
                if (participaredWorkers[i].DentalCheckUpId == id)
                {
                    dentalCheckWorkersInDb.IdList.Add(participaredWorkers[i].WorkerId);
                    _dentalCheckWorkerRepository.DeleteDentalCheckWorker(id);
                }
            }
            return dentalCheckWorkersInDb;
        }

        public _DentalCheckWorkers EditDentalCheckWorkers(_DentalCheckWorkers dentalCheckWorkers, int id)
        {
            this.DeleteDentalCheckWorkers(id);
            this.AddDentalCheckWorkers(dentalCheckWorkers);
            return dentalCheckWorkers;
        }

        

        public _DentalCheckWorkers GetDentalCheckWorkers(int id)
        {
            var dentalCheckWorker = _dentalCheckWorkerRepository.GetAll().ToList();
            _DentalCheckWorkers dentalCheckAndkWorkers = new _DentalCheckWorkers()
            {
                DentalCheckUpId = id
            };
            for(int i = 0; i < dentalCheckWorker.Count(); i++)
            {
                if (dentalCheckWorker[i].DentalCheckUpId == dentalCheckAndkWorkers.DentalCheckUpId)
                    dentalCheckAndkWorkers.IdList.Add(dentalCheckWorker[i].WorkerId);
            }
            return dentalCheckAndkWorkers;
        }

        public IEnumerable<_DentalCheckWorkers> GetDentalChecsAndkWorkers()
        {
            var dentalChecks = _dentalCheckRepository.GetDentalChecks().ToList();
            var dentalCheckWorker = _dentalCheckWorkerRepository.GetAll().ToList();
            List<_DentalCheckWorkers> dentalChecksAndWorkers = new List<_DentalCheckWorkers>();
            for(int i = 0; i < dentalChecks.Count(); i++)
            {
                _DentalCheckWorkers dentalCheckWORKERS = new _DentalCheckWorkers()
                {
                    DentalCheckUpId = dentalChecks[i].Id
                };
                for(int j = 0; j < dentalCheckWorker.Count(); j++)
                {
                    if (dentalCheckWorker[j].DentalCheckUpId == dentalCheckWORKERS.DentalCheckUpId)
                        dentalCheckWORKERS.IdList.Add(dentalCheckWorker[j].WorkerId);

                }
                dentalChecksAndWorkers.Add(dentalCheckWORKERS);
            }
            return dentalChecksAndWorkers;
        }

        
    }
}
