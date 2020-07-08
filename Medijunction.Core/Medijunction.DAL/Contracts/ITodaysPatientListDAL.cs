using MediJunction.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Medijunction.DAL.Contracts
{
    public interface ITodaysPatientListDAL : IData
    {
        void Add(TodaysPatientList entity);
        TodaysPatientList Get(int patientId);
        IQueryable<TodaysPatientList> FindBy(Expression<Func<TodaysPatientList, bool>> predicate);
    }
}
