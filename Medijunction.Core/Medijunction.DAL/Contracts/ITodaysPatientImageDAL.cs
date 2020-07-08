using MediJunction.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medijunction.DAL.Contracts
{
    public interface ITodaysPatientImageDAL : IData
    {
        void Add(TodaysPatientImage entity);
        TodaysPatientImage Get(int patientId);
        IQueryable<TodaysPatientImage> FindBy(System.Linq.Expressions.Expression<Func<TodaysPatientImage, bool>> predicate);
    }
}
