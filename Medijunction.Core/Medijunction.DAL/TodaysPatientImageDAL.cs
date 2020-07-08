using Medijunction.DAL.Contracts;
using MediJunction.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Medijunction.DAL
{
    public class TodaysPatientImageDAL : ITodaysPatientImageDAL 
    {
        IEFRepository<TodaysPatientImage> _eFRepository;
        public TodaysPatientImageDAL(IEFRepository<TodaysPatientImage> eFRepository)
        {
            _eFRepository = eFRepository;
        }

        public void Add(TodaysPatientImage entity)
        {
            _eFRepository.Add(entity);
            _eFRepository.Save();
        }

        public IQueryable<TodaysPatientImage> FindBy(Expression<Func<TodaysPatientImage, bool>> predicate)
        {
            return _eFRepository.FindBy(predicate);
        }

        public TodaysPatientImage Get(int patientId)
        {
            return _eFRepository.Get(patientId);
        }
    }
}
