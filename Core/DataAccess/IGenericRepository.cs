using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter =null);
        T GetById(int entityId);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int entityId);

    }
}
