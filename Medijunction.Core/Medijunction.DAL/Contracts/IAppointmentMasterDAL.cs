using MediJunction.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medijunction.DAL.Contracts
{
    public interface IAppointmentMasterDAL : IData
    {
        void Add(AppointmentMaster entity);
        AppointmentMaster Get(Guid AppointmentId);
    }
}
