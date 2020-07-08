using MediJunction.DomainModel;
using MediJunction.DomainModel.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medijunction.DAL.Contracts
{
    public interface IEFRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        void Delete(T entity);
        T Get(object id);
        IQueryable<T> Get();
        IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        void Edit(T entity);
        void Save();
    }
}
