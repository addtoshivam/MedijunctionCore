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
        private MediJunctionContext DbContext { get; set; }
        private DbSet<T> DbSet { get; set; }

        public EFRepository(MediJunctionContext context)
        {
            DbContext = context;
            DbSet = context.Set<T>();
        }

        public T Add(T entity)
        {
            var v = DbSet.Add(entity);
            return v.Entity;
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public T Get(object id)
        {
           return DbSet.Find(id);
        }

        public IQueryable<T> Get()
        {
            return DbSet.AsQueryable();
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = DbSet.Where(predicate).AsQueryable();
            return query;
        }

        public void Edit(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }
    }
}
