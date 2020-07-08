using Medijunction.DAL.Contracts;
using MediJunction.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Medijunction.DAL
{
    public class TodaysPatientListDAL : ITodaysPatientListDAL 
    {
        IEFRepository<TodaysPatientList> _eFRepository;
        public TodaysPatientListDAL(IEFRepository<TodaysPatientList> eFRepository)
        {
            _eFRepository = eFRepository;
        }

        public void Add(TodaysPatientList entity)
        {
            _eFRepository.Add(entity);
            _eFRepository.Save();
        }

        public TodaysPatientList Get(int patientId)
        {
            return _eFRepository.Get(patientId);
        }
        
        public IQueryable<TodaysPatientList> FindBy(Expression<Func<TodaysPatientList, bool>> predicate)
        {
            return _eFRepository.FindBy(predicate);
        }
    }
}
