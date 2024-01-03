﻿using Maui.CommandPattern.EntityLibrary.Models;

namespace Maui.CommandPattern.BlazorHybrid.Repositories
{
    public interface IRepositoryBase<T> where T : ModelBase
    {
        T Add(T entity);

        bool Delete(T entity);

        bool DeleteById(int entityId);

        IEnumerable<T> Filter(Func<T, bool> predicate);

        IEnumerable<T> GetAll();

        T? GetById(int id);

        T Update(T entity);
    }
}
