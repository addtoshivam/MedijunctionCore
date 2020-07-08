using Medijunction.DAL.Contracts;
using MediJunction.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medijunction.DAL
{
    public class AppointmentMasterDAL : IAppointmentMasterDAL 
    {
        IEFRepository<AppointmentMaster> _eFRepository;
        public AppointmentMasterDAL(IEFRepository<AppointmentMaster> eFRepository)
        {
            _eFRepository = eFRepository;
        }

        public void Add(AppointmentMaster entity)
        {
            _eFRepository.Add(entity);
            _eFRepository.Save();
        }

        public AppointmentMaster Get(Guid AppointmentId)
        {
            return _eFRepository.Get(AppointmentId);
        }
    }
}
