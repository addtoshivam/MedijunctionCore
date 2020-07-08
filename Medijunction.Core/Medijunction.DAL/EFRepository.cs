using Medijunction.DAL.Contracts;
using MediJunction.DomainModel;
using MediJunction.DomainModel.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Medijunction.DAL
{
    public class EFRepository<T>: IEFRepository<T> where T: BaseEntity
    {
        private readonly MediJunctionContext _dbContext;
        private DbSet<T> _dbSet;

        public EFRepository(MediJunctionContext context)
        {
            _dbContext = context;
        }

        public T Add(T entity)
        {
            var v = _dbSet.Add(entity);
            return v.Entity;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public T Get(object id)
        {
           return _dbSet.Find(id);
        }

        public IQueryable<T> Get()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbSet.Where(predicate).AsQueryable();
            return query;
        }

        public void Edit(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
