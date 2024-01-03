using Maui.CommandPattern.BlazorHybrid.Repositories;
using Maui.CommandPattern.EntityLibrary.Models;

namespace Maui.CommandPattern.BlazorHybrid.Services
{
    public class ServiceBase<T,TRepo> : IServiceBase<T>
        where T : ModelBase
        where TRepo : IRepositoryBase<T>
    { 
        private TRepo Repo;

        public ServiceBase(TRepo repo)
        {
            Repo = repo;
        }

        public virtual T Add(T entity)
        {
            try
            {
                return Repo.Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual bool Delete(T entity)
        {
            try
            {
                return Repo.Delete(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual bool DeleteById(int entityId)
        {
            try
            {
                return Repo.DeleteById(entityId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual IEnumerable<T> Filter(Func<T, bool> predicate)
        {
            try
            {
                return Repo.Filter(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return Repo.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual T? GetById(int id)
        {
            try
            {
                return Repo.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual T Update(T entity)
        {
            try
            {
                return Repo.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
