using MediJunction.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medijunction.DAL.Contracts
{
    public interface IPreconsulationDAL : IData
    {
        void Add(PreConsultation entity);
        PreConsultation Get(Guid AppointmentId);
    }
}
