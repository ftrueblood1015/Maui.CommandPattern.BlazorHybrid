using Maui.CommandPattern.EntityLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace Maui.CommandPattern.BlazorHybrid.Repositories
{
    public class RepositoryBase<T, TContext> : IRepositoryBase<T>
        where TContext : DbContext
        where T : ModelBase
    {
        public TContext Context { get; private set; }

        public RepositoryBase(TContext context)
        {
            Context = context;
        }

        public T Add(T entity)
        {
            _ = Context.Set<T>().Add(entity);

            Context.SaveChanges();

            return GetById(entity.Id)!;
        }

        public bool Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            var results = Context.SaveChanges();

            return results > 0;
        }

        public bool DeleteById(int entityId)
        {
            var entity = Filter(x => x.Id == entityId).Single();

            Context.Set<T>().Remove(entity);
            var results = Context.SaveChanges();

            return results > 0;
        }

        public virtual IEnumerable<T> Filter(Func<T, bool> predicate)
        {
            return Context.Set<T>().AsNoTracking().Where(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public virtual T? GetById(int id)
        {
            return Context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public T Update(T entity)
        {
            Context.Set<T>().Update(entity);
            Context.SaveChanges();

            return GetById(entity.Id)!;
        }
    }
}
