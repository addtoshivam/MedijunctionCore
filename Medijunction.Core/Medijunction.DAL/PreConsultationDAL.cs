using Medijunction.DAL.Contracts;
using MediJunction.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Medijunction.DAL
{
    public class PreConsultationDAL : IPreconsulationDAL 
    {
        IEFRepository<PreConsultation> _eFRepository;
        public PreConsultationDAL(IEFRepository<PreConsultation> eFRepository)
        {
            _eFRepository = eFRepository;
        }

        public void Add(PreConsultation entity)
        {
            _eFRepository.Add(entity);
            _eFRepository.Save();
        }

        public PreConsultation Get(Guid preConsultationId)
        {
            return _eFRepository.Get(preConsultationId);
        }
    }
}
